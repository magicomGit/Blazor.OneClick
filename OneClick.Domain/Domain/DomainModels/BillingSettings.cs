using OneClick.Domain.Enums.Transaction;

namespace OneClick.Domain.Domain.DomainModels
{
    public class BillingSettings
    {
        public bool AutoOff { get; set; }
        public int DaysBeforeBill { get; set; }
        public int DaysBeforeDelete { get; set; }
        public double ReferalBonus { get; set; }
        public int ReferalLevels { get; set; }
        public int PartFirstReferal { get; set; }
        public List<PaymentSystem> SelectedPayments { get; set; } = new List<PaymentSystem>();
        public PaymentSystem DefaultPayment { get; set; }
        public string? Network { get; set; }
        public string? WalletAddress { get; set; }
        public string? CryptomusApiKey { get; set; }
        public string? CryptomusMerchantId { get; set; }
        public string? CryptomusCallbackUrl { get; set; }
        public string? CryptomusRedirectUrl { get; set; }
    }
}
