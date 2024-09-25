using OneClick.Data.Enums;
using OneClick.Domain.Enums.Customer;

namespace OneClick.Data.Data
{
    public class Alert
    {
        public long Id { get; set; }
        public AppSeverity Severity { get; set; } = AppSeverity.Error;
        public string? Message { get; set; } = string.Empty;
        public string? Issuer { get; set; }
        public string? Link { get; set; }
        public DateTime DisposeTime { get; set; }
        public int NotificationCount { get; set; }
        public bool ShowCloseIcon { get; set; }
        public bool ShowModal { get; set; }
    }

    
}
