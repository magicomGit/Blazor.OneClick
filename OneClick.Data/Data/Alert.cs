using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClick.Data.Data
{
    public class Alert
    {
        public long Id { get; set; }
        public Severity Severity { get; set; } = Severity.Error;
        public string? Message { get; set; } = string.Empty;
        public string? Issuer { get; set; }
        public string? Link { get; set; }
        public DateTime DisposeTime { get; set; }
        public int NotificationCount { get; set; }
        public bool ShowCloseIcon { get; set; }
        public bool ShowModal { get; set; }
    }

    public enum Severity
    {
        [Description("normal")]
        Normal,
        [Description("info")]
        Info,
        [Description("success")]
        Success,
        [Description("warning")]
        Warning,
        [Description("error")]
        Error
    }
}
