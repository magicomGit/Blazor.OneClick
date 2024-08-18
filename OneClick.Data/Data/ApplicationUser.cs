using Microsoft.AspNetCore.Identity;

namespace OneClick.Data.Data
{
    public class ApplicationUser : IdentityUser
    {
        public long TelegramId { get; set; }
        public string? Telegram { get; set; }
        public string? FirstName { get; set; }
        public string? Phone { get; set; }
        public string? Avatar { get; set; }
        public virtual List<Alert>? Alerts { get; set; }
        public virtual Balance? Balance { get; set; }
        public UserStatus Status { get; set; }
        public DateTime Registered { get; set; }
        public DateTime LastActivity { get; set; }
        public virtual AccountPayment? PaymentInfo { get; set; }
        public string? Language { get; set; }
    }

    public class Balance
    {
        public long Id { get; set; }
        public double WalletBalance { get; set; }
        public double AwaitTransaction { get; set; }
        public string? Network { get; set; }
        public string? WalletAddress { get; set; }
    }

    public class AccountPayment
    {
        public long Id { get; set; }
        public DateTime LastPayment { get; set; }
        public DateTime LastPaymentRemind { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }

    }

    public enum UserStatus
    {
        Frozen,
        AwaitPay,
        Active,
        None
    }
}
