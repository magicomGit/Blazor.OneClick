using System.ComponentModel;

namespace OneClick.Domain.Enums.Customer
{
    public enum AppSeverity
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

    public enum UserTheme
    {
        Light,
        Dark,

    }
}
