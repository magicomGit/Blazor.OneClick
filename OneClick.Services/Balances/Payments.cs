using OneClick.Domain.Domain.DomainServices;
using OneClick.Domain.Domain.OneClickProjects;
using OneClick.UseCases.Intefaces.App;
using OneClick.UseCases.Intefaces.Balances;

namespace OneClick.Services.Balances
{
    public class Payments : IPayments
    {
        private IAppSettingsRepository _appSettingsRepository;

        public Payments(IAppSettingsRepository appSettingsRepository)
        {
            _appSettingsRepository = appSettingsRepository;
        }

        public async Task<DateTime?> GetFreezeDay(List<CopyTradingProject> projects, double balance)
        {
            DateTime? FreezeDay = null;
            var servicesPrice = await _appSettingsRepository.GetServicesPrices();
            double DayFee = 0;
            double overpayment = 0;
            foreach (var project in projects)
            {
                if (project.State == ProjectState.Ready || project.State == ProjectState.FrozenByOwner)
                {
                    var overpaymentDays = (project.Payment.LastPayment - DateTime.UtcNow).TotalDays;
                    var fee = GetProjectPaymentAmount(project, servicesPrice);
                    if (overpaymentDays > 0)
                    {
                        overpayment += overpaymentDays * fee;
                    }
                    DayFee += fee;
                }
            }
            if (DayFee != 0)
            {
                int daysBeforeFreeze = (int)((balance + overpayment) / DayFee);
                FreezeDay = DateTime.UtcNow.AddDays(daysBeforeFreeze + 1);

            }

            return FreezeDay;
        }

        public  double GetProjectPaymentAmount(CopyTradingProject project, ServicesPrice servicesPrice)
        {
            var investorCount = 1;//минимальное количество
            var traderCount = 1;

            if (project.UserCount > investorCount && project.State != ProjectState.FrozenByOwner)
            {
                investorCount = project.UserCount;
            }

            if (project.TraderCount > traderCount && project.State != ProjectState.FrozenByOwner)
            {
                traderCount = project.TraderCount;
            }

            double amount = 0;
            
            var tariffprices = GetTariffPrices(project.Tariff, servicesPrice);

            amount += tariffprices.TraderRateDaily * traderCount;
            amount += tariffprices.UserRateDaily * investorCount;




            return amount;
        }

        private  TariffPrices GetTariffPrices(ProjectTariff tariff, ServicesPrice servicesPrice)
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
