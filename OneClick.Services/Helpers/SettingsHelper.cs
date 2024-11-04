using OneClick.Domain.Domain.DomainModels;
using OneClick.Domain.Domain.OneClickProjects;
using OneClick.Domain.Enums.Project;

namespace OneClick.Services.Helpers
{
    public static class SettingsHelper
    {
        public static TariffPrices GetTariffPrices(ProjectTariff tariff, ServicesPrice servicesPrice)
        {
            var prices = new TariffPrices();

            switch (tariff)
            {
                case ProjectTariff.Start:
                    prices.CreateProjectRate = servicesPrice.CreateProjectRate;
                    prices.TraderRate = servicesPrice.TraderRate;
                    prices.TraderRateDaily = Math.Round(servicesPrice.TraderRate / 30, 2);
                    prices.UserRate = servicesPrice.UserRate;
                    prices.UserRateDaily = Math.Round(servicesPrice.UserRate / 30, 2);
                    prices.ExchangeRate = servicesPrice.ExchangeRate;
                    prices.CrossTradingRate = servicesPrice.CrossTradingRate;
                    prices.BillingRate = servicesPrice.BillingRate;
                    prices.AddDomainRate = servicesPrice.AddDomainRate;
                    prices.MaxExchangeRequestInOneMinute = servicesPrice.MaxExchangeRequestInOneMinute;
                    prices.MaxExchangeRequestInFiveMinutes = servicesPrice.MaxExchangeRequestInFiveMinutes;
                    break;
                case ProjectTariff.Company:
                    prices.CreateProjectRate = servicesPrice.CreateProjectRate2;
                    prices.TraderRate = servicesPrice.TraderRate2;
                    prices.TraderRateDaily = Math.Round(servicesPrice.TraderRate2 / 30, 2);
                    prices.UserRate = servicesPrice.UserRate2;
                    prices.UserRateDaily = Math.Round(servicesPrice.UserRate2 / 30, 2);
                    prices.ExchangeRate = servicesPrice.ExchangeRate2;
                    prices.CrossTradingRate = servicesPrice.CrossTradingRate2;
                    prices.BillingRate = servicesPrice.BillingRate2;
                    prices.AddDomainRate = servicesPrice.AddDomainRate2;
                    prices.MaxExchangeRequestInOneMinute = servicesPrice.MaxExchangeRequestInOneMinute2;
                    prices.MaxExchangeRequestInFiveMinutes = servicesPrice.MaxExchangeRequestInFiveMinutes2;
                    break;
                default:
                    break;
            }

            return prices;
        }
    }
}
