namespace ams.service.services;

internal class UserService(IUnitOfWork _unitOfWork) : IUserService
{
    public async Task AddUserAsync(UserDto user)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));

        await _unitOfWork.UserRepository.AddUserAsync(user.Adapt<User>());
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteUserAsync(int userId)
    {
        var user = await _unitOfWork.UserRepository.GetUserByIdAsync(userId)
            ?? throw new RecordNotFoundException($"User with ID: {userId} not found");

        _unitOfWork.UserRepository.DeleteUser(user);
        await _unitOfWork.SaveAsync();
    }

    public async Task<UserDto?> GetUserByEmailAsync(string email, bool failIfNotExists = true)
    {
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email cannot be empty", nameof(email));
        var user = await _unitOfWork.UserRepository.GetUserByEmailAsync(email);
        if (failIfNotExists && user == null)
        {
            throw new RecordNotFoundException($"User with email: {email} does not exist");
        }
        if (user == null) return null;
        return user.Adapt<UserDto>();
    }

    public async Task<UserDto?> GetUserWithLoginHistoryAsync(int userId)
    {
        var user = await _unitOfWork.UserRepository.GetUserWithLoginHistoryAsync(userId)
            ?? throw new RecordNotFoundException($"Login history for User ID: {userId} does not exist");

        return user.Adapt<UserDto>();
    }

    public async Task UpdateUserAsync(UserDto user)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));

        var existingUser = await _unitOfWork.UserRepository.GetUserByIdAsync(user.UserId)
            ?? throw new RecordNotFoundException($"User with ID: {user.UserId} not found");

        // Prevent unnecessary changes when no modifications are present
        if (existingUser.FullName != user.FullName || existingUser.Email != user.Email)
        {
            existingUser.FullName = user.FullName;
            existingUser.Email = user.Email;

            await _unitOfWork.SaveAsync();
        }
    }
}

