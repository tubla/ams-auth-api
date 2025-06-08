namespace ams.service.repositories;

internal class UserRepository(AuthDbContext _context) : IUserRepository
{
    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetUserByIdAsync(int userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    public async Task<User?> GetUserWithLoginHistoryAsync(int userId)
    {
        return await _context.Users
            .Include(u => u.LoginHistories)
            .FirstOrDefaultAsync(u => u.UserId == userId);
    }

    public async Task AddUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public void DeleteUser(User user)
    {
        if (user != null)
        {
            _context.Users.Remove(user);
        }
    }
}


