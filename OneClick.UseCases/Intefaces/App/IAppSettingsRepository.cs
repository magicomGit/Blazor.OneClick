using OneClick.Domain.Domain.DomainServices;

namespace OneClick.UseCases.Intefaces.App
{
    public interface IAppSettingsRepository
    {
        Task<ServicesPrice> GetServicesPrices();
    }
}
