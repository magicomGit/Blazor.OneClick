using OneClick.Domain.Enums.Customer;

namespace OneClick.Domain.Domain.Customers
{
    public class CustomerAlert
    {
        public long Id { get; set; }
        public AppSeverity Severity { get; set; } = AppSeverity.Error;
        public string Message { get; set; } = string.Empty;
        public string? Issuer { get; set; }
        public string? Link { get; set; }
        public DateTime DisposeTime { get; set; }
        public DateTime Time { get; set; }
        public int NotificationCount { get; set; }

    }
}
