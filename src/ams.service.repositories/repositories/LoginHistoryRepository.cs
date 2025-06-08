namespace ams.service.repositories;

internal class LoginHistoryRepository(AuthDbContext _context) : ILoginHistoryRepository
{
    public async Task<List<LoginHistory>> GetLoginHistoryByUserAsync(int userId)
    {
        return await _context.LoginHistories
            .Where(lh => lh.UserId == userId)
            .ToListAsync();
    }

    public async Task AddLoginHistoryAsync(LoginHistory loginHistory)
    {
        await _context.LoginHistories.AddAsync(loginHistory);
    }
}

