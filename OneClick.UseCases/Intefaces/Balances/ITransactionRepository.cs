namespace OneClick.UseCases.Intefaces.Balances
{
    public interface ITransactionRepository<IResponse,TTransaction>
    {
        Task<IResponse> GetById(long transactionId);
        Task<List<TTransaction>> Get();
        Task<IResponse> Update(TTransaction transaction);
        Task<IResponse> Add(TTransaction transaction);
    }
}
