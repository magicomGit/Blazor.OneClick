using OneClick.Domain.Enums.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClick.Domain.Domain.Customers
{
    public class CustomerAlert
    {
        public long Id { get; set; }
        public Severity Severity { get; set; } = Severity.Error;
        public string Message { get; set; } = string.Empty;
        public string? Issuer { get; set; }
        public string? Link { get; set; }
        public DateTime DisposeTime { get; set; }
        public DateTime Time { get; set; }
        public int NotificationCount { get; set; }
        
    }
}
