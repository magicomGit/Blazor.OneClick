using OneClick.Domain.Enums.Transaction;
using TransactionStatus = OneClick.Domain.Enums.Transaction.TransactionStatus;

namespace OneClick.Data.Data
{
    public class BalanceTransaction
    {
        public long Id { get; set; }
        public TransactionCode Code { get; set; }
        public Guid IssuerId { get; set; }
        public PaymentSystem PaySystem { get; set; }
        public string? PayId { get; set; } //id платежа в платежной системе
        public string? Issuer { get; set; }
        public double Summ { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public TransactionType Type { get; set; }
        public TransactionStatus Status { get; set; }
        public virtual List<BalanceOperation>? Operations { get; set; }
    }


    public class BalanceOperation
    {
        public long Id { get; set; }
        public double Summ { get; set; }
        public Guid UserId { get; set; }
        public string? UserLogin { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public double LastBalance { get; set; }
        public OpirationType Type { get; set; }
        public OperationDirection Direction { get; set; }
        public TransactionCode Code { get; set; }
        public PaymentSystem PaySystem { get; set; }
        public string? PayId { get; set; } //id платежа в платежной системе
    }
}
