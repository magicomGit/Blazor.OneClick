using OneClick.Domain.Enums.Customer;

namespace Blazor.OneClick.Models
{
    public class CustomMessage
    {
        public AppSeverity Severity { get; set; } = AppSeverity.Error;
        public string? Message { get; set; } = string.Empty;
        public bool IsVisible { get; set; }

        public CustomMessage() { }
        public CustomMessage(AppSeverity severity, string message)
        {
            Severity = severity;
            Message = message;
            IsVisible = true;

        }
    }
}
