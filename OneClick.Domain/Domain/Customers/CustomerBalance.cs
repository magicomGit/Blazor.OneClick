namespace OneClick.Domain.Domain.Customers
{
    public class CustomerBalance
    {
        public long Id { get; set; }
        public double WalletBalance { get; set; }        
        public string? Network { get; set; }
        public string? WalletAddress { get; set; }
        public double AwaitTransaction { get; set; }
    }
}
