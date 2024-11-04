using OneClick.Domain.Enums.Project;

namespace OneClick.UseCases.Intefaces.Balances
{
    public interface IInvoiceService<TResponse,  Tproject>
    {
        Task<TResponse> EditProjectInvoice(Tproject newProject, Tproject oldProject, ProjectTariff tariff);
    }
}
