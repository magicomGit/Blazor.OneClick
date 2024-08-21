using CSharpFunctionalExtensions;

namespace OneClick.Domain.Domain.OneClickProjects.ValueObjects
{
    public class TelegramBot : ValueObject
    {
        public string TelegramBotName { get; }
        public string TelegramBotKey { get; }


        private TelegramBot(string TelegramBotName, string TelegramBotKey)
        {
            this.TelegramBotName = TelegramBotName;
            this.TelegramBotKey = TelegramBotKey;
        }
        private TelegramBot() { }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }

        public static Result<TelegramBot, string> Create(string TelegramBotName, string TelegramBotKey)
        {
            if (string.IsNullOrEmpty(TelegramBotName) || string.IsNullOrEmpty(TelegramBotKey))
            {
                return "Значения не заданы";
            }

            return new TelegramBot(TelegramBotName, TelegramBotKey);
        }
    }
}
