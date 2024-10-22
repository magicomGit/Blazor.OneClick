using OneClick.Domain.Domain.DomainServices;

namespace OneClick.UseCases.Intefaces.App
{
    public interface IAppSettingsRepository
    {
        Task<ServicesPrice> GetServicesPrices();
        Task<AppSettings> GetAppSettings();
        Task<string> GetDefaultAvatar();
        Task<string> GetSystemLogo();
    }
}
