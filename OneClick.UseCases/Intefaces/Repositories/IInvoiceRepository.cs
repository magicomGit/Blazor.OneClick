namespace OneClick.UseCases.Intefaces.Repositories
{
    public interface IInvoiceRepository<IResponse>
    {
        Task<IResponse> GetById(long id);
    }
}
