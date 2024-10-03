using OneClick.Domain.Enums.Transaction;

namespace OneClick.UseCases.Intefaces.Balances
{
    public interface ITransactions<TResponse>
    {
        Task<TResponse> ApplyDeposit(Guid userId, PaymentSystem paymentSystem, double summ, string description);
        Task<TResponse> ApproveDeposit(Guid implementerId, long transactionId, double summ, string description, string payId);
       
        
    }
}
