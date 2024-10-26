using OneClick.Domain.Domain.DomainModels;

namespace OneClick.UseCases.Intefaces.App
{
    public interface IAppSettingsRepository
    {
        Task<ServicesPrice> GetServicesPrices();
        Task<AppSettings> GetAppSettings();
        Task<BillingSettings> GetBillingSettings();
        Task<string> GetDefaultAvatar();
        Task<string> GetSystemLogo();
        Task<string> GetAdminId();
    }
}
