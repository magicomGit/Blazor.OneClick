using OneClick.Domain.Enums.Customer;

namespace OneClick.Domain.Domain.Customers
{
    public class Customer
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public long TelegramId { get; set; }
        public string? Telegram { get; set; }
        public string? FirstName { get; set; }
        public string? Phone { get; set; }
        public string? Avatar { get; set; }
        public List<CustomerAlert>? Alerts { get; set; }
        public CustomerBalance Balance { get; set; }

        public DateTime Registered { get; set; }
        public DateTime LastActivity { get; set; }
        public CustomerPayment Payment { get; set; }
        public string? Language { get; set; }
        public UserTheme Theme { get; set; }


        public Customer(string id, string userName, long telegramId, string telegram, string firstName, string phone, string avatar,
            List<CustomerAlert> alerts, CustomerBalance balance, DateTime registered, DateTime lastActivity, CustomerPayment payment, string? language, UserTheme theme)
        {
            Id = id;
            UserName = userName;
            TelegramId = telegramId;
            Telegram = telegram;
            FirstName = firstName;
            Phone = phone;
            Avatar = avatar;
            Alerts = alerts;
            Balance = balance;
            Registered = registered;
            LastActivity = lastActivity;
            Payment = payment;
            Language = language;
            Theme = theme;
        }
    }
}
