using static OneClick.Domain.Enums.App.AppEnums;

namespace OneClick.Domain.Domain.DomainModels
{
    public class AppSettings
    {
        public string? SystemName { get; set; }
        public string? SystemDomain { get; set; }
        public string? IPAddress { get; set; }
        public string? TelegramBotName { get; set; }
        public string? TelegramBotKey { get; set; }
        public string? GreetingMessage { get; set; }
        public string? Reminder { get; set; }
        public ReminderSet ReminderOften { get; set; }
    }
}
