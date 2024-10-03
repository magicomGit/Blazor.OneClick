using OneClick.Domain.Enums.Transaction;

namespace OneClick.Domain.Domain.Balances
{
    public class OneClickTransaction
    {
        public long Id { get; private set; }
        public TransactionCode Code { get; private set; }
        public Guid IssuerId { get; set; }
        public PaymentSystem PaySystem { get; private set; }
        public string? PayId { get; private set; } //id платежа в платежной системе
        public string? Issuer { get; private set; }
        public double Summ { get; private set; }
        public DateTime Date { get; private set; }
        public string? Description { get; private set; }
        public TransactionType Type { get; private set; }
        public TransactionStatus Status { get; private set; }
        public List<Operation>? Operations { get; private set; }

        public OneClickTransaction(long id, TransactionCode code, Guid issuerId, PaymentSystem paySystem, string payId, string issuer, double summ,
            DateTime date, string description, TransactionType type, TransactionStatus status, List<Operation> operations) 
        {
        Id = id;
            Code = code;
            IssuerId = issuerId;
            PaySystem = paySystem;
            PayId = payId;
            Issuer = issuer;
            Summ = summ;
            Date = date;
            Description = description;
            Type = type;
            Status = status;
            Operations = operations;
        }

        public void ChangeStatus(TransactionStatus status)
        {
            Status = status;
        }


        public void SetSumm(double summ)
        {
            Summ = summ;
        }

    }

    public class Operation
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

        public Operation(long id, double summ, Guid userId, string userLogin, DateTime date, string description,
            double lastBalance, OpirationType type, OperationDirection direction, TransactionCode code, PaymentSystem paySystem, string payId)
        {
            Id = id;
            Summ = Summ;
            UserId = userId;
            UserLogin = userLogin;
            Date = date;
            Description = description;
            LastBalance = lastBalance;
            Type = type;
            Direction = direction;
            Code = code;
            PaySystem = paySystem;
            PayId = payId;
        }
    }
}
