namespace ams.service.services;

public interface IUserService
{
    Task<UserDto?> GetUserByEmailAsync(string email, bool failIfNotExists = true);
    Task<UserDto?> GetUserWithLoginHistoryAsync(int userId);
    Task AddUserAsync(UserDto user);
    Task UpdateUserAsync(UserDto user);
    Task DeleteUserAsync(int userId);
}
