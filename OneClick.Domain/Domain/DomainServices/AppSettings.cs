using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OneClick.Domain.Enums.App.AppEnums;

namespace OneClick.Domain.Domain.DomainServices
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
