using OneClick.Domain.Domain.OneClickProjects;

namespace OneClick.UseCases.Intefaces.Balances
{
    public interface IPayments
    {
        Task<DateTime?> GetFreezeDay(List<CopyTradingProject> projects, double balance);
    }
}
