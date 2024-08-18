using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClick.Domain.Enums.Customer
{
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
