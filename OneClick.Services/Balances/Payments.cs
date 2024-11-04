using OneClick.Domain.Domain.DomainModels;
using OneClick.Domain.Domain.OneClickProjects;
using OneClick.Domain.Enums.Project;
using OneClick.Services.Helpers;
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
            
            var tariffprices = SettingsHelper.GetTariffPrices(project.Tariff, servicesPrice);

            amount += tariffprices.TraderRateDaily * traderCount;
            amount += tariffprices.UserRateDaily * investorCount;




            return amount;
        }

       
    }
}
