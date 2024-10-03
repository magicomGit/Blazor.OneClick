namespace OneClick.UseCases.Intefaces.Balances
{
    public interface ITransactionRepository<TTransaction>
    {
        Task<TTransaction> GetById(long transactionId);
        Task<List<TTransaction>> Get();
        Task<bool> Update(TTransaction transaction);
        Task<bool> Add(TTransaction transaction);
    }
}
