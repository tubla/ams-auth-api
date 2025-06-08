namespace ams.service.repositories;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string email);
    Task<User?> GetUserByIdAsync(int userId);
    Task<User?> GetUserWithLoginHistoryAsync(int userId);
    Task AddUserAsync(User user);
    void DeleteUser(User user);
}
