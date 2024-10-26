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

        Task<bool> SaveBillingSettings(BillingSettings settings);
        Task<bool> SaveAppSettings(AppSettings settings);
        Task<bool> SaveServicesPrices(ServicesPrice settings);
        Task<bool> SaveAvatar(string settings);
        Task<bool> SaveSystemLogo(string settings);
    }
}
