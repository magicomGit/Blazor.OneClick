﻿using OneClick.Data.Enums;
using OneClick.Domain.Enums.Customer;

namespace OneClick.Data.Data
{
    public class Payment
    {
        public long Id { get; set; }
        public DateTime LastPayment { get; set; }
        public DateTime LastFreeze { get; set; }
        public DateTime LastFreezeReminded { get; set; }
        public DateTime LastDeleteReminded { get; set; }
        public bool IsFreezeReminded { get; set; }
        public bool IsDeleteReminded { get; set; }
        public string? Message { get; set; }
        public AppSeverity Severity { get; set; }
    }
}
