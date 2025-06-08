namespace ams.service.services;

internal class LoginHistoryService(IUnitOfWork _unitOfWork) : ILoginHistoryService
{
    public async Task<List<LoginHistoryDto>> GetLoginHistoryByUserAsync(int userId)
    {
        var loginHistory = await _unitOfWork.LoginHistoryRepository.GetLoginHistoryByUserAsync(userId);
        return loginHistory.Select(lh => lh.Adapt<LoginHistoryDto>()).ToList();
    }

    public async Task AddLoginHistoryAsync(LoginHistoryDto loginHistory)
    {
        await _unitOfWork.LoginHistoryRepository.AddLoginHistoryAsync(loginHistory.Adapt<LoginHistory>());
        await _unitOfWork.SaveAsync();
    }
}
