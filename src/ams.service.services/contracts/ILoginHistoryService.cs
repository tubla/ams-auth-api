
namespace ams.service.services;

public interface ILoginHistoryService
{
    Task AddLoginHistoryAsync(LoginHistoryDto loginHistory);
    Task<List<LoginHistoryDto>> GetLoginHistoryByUserAsync(int userId);
}