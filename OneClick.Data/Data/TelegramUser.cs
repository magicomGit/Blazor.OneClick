namespace OneClick.Data.Data
{
    public class TelegramUser
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? OneClickLogin { get; set; }
        public string? OneClickUserId { get; set; }
        public string? Language { get; set; }
        public long TelegramId { get; set; }
        public DateTime Registered { get; set; }
        public DateTime LastActivity { get; set; }
        public DateTime RegisteredInOneClick { get; set; }
    }
}
