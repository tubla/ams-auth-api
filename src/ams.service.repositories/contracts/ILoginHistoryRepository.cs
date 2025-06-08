
namespace ams.service.repositories;

public interface ILoginHistoryRepository
{
    Task AddLoginHistoryAsync(LoginHistory loginHistory);
    Task<List<LoginHistory>> GetLoginHistoryByUserAsync(int userId);
}