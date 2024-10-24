namespace OneClick.Domain.Enums.Transaction
{
    public enum TransactionCode
    {
        Deposit,
        Withdraw,
        Payment,
        RejectWithdraw,
        ApproveWithdraw,
        ApplyWithdraw,
        ReturnPayment,
        ReferralBonus,
        RejectDeposit,
        ApproveDeposit,
        ApplyDeposit,
    }
    public enum TransactionType
    {
        Deposit,
        Withdraw,
        Transfer,
    }
    public enum OpirationType
    {
        Apply,
        Transfer,
        Approve,
        Reject,
    }

    public enum TransactionStatus
    {
        Await,
        Completed,
        Rejected,

    }

    public enum OperationDirection
    {
        None,
        Income,
        Expense

    }

    public enum PaymentSystem
    {
        None,
        PaymentViaAdmin,
        Cryptomus,


    }
}
