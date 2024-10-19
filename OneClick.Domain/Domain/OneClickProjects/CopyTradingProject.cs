using OneClick.Domain.Domain.OneClickProjects.ValueObjects;

namespace OneClick.Domain.Domain.OneClickProjects
{
    public class CopyTradingProject
    {
        public int Id { get; set; }
        public Guid OwnerId { get; set; }
        public string? OwnerName { get; set; }
        public string? ProjectDomain { get; set; }
        public TelegramBot TelegramBot { get; }
        public string? TelegramKey { get; set; }
        public string? ProjectName { get; set; }
        public string? ServerIP { get; set; }
        public string? ServerName { get; set; }
        public int ServerId { get; set; }
        public int ProxyCount { get; set; }
        public int TraderMaxCount { get; set; }

        public int UserMaxCount { get; set; }
        public int TraderCount { get; set; }
        public int UserCount { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastPing { get; set; }
        public ProjectState State { get; set; }

        public List<ExchangeMarket> Exchanges { get; set; }

        public bool BillingEnabled { get; set; }
        public bool CrossTradingEnabled { get; set; }
        public bool Synchronized { get; set; }
        public ProjectPayment? Payment { get; set; }
        public string? Logo { get; set; }
        public ProjectTariff Tariff { get; set; }
        public string? DefaultLanguage { get; set; }
        public List<Language>? Languages { get; set; }
        public double DayFee { get; set; }
        public string AdminTelegram { get; set; }
        public long AdminTelegramId { get; set; }




        private CopyTradingProject()
        {

        }
        public CopyTradingProject(int id, Guid ownerId, string ownerName, string projectDomain, TelegramBot telegramBot, string projectName,
            string serverIP, string serverName, int serverId, int proxyCount, int traderMaxCount, int userMaxCount, int traderCount, int userCount,
            DateTime createDate, DateTime lastPing, ProjectState state, List<ExchangeMarket> exchanges, ProjectPayment payment, string logo,
            ProjectTariff tariff, string defaultLanguage, List<Language> languages, double dayFee, string adminTelegram, long adminTelegramId)
        {
            Id = id;
            OwnerId = ownerId;
            OwnerName = ownerName;
            ProjectDomain = projectDomain;
            TelegramBot = telegramBot;
            ProjectName = projectName;
            ServerIP = serverIP;
            ServerName = serverName;
            ServerId = serverId;
            ProxyCount = proxyCount;
            UserMaxCount = userMaxCount;
            TraderMaxCount = traderMaxCount;
            TraderCount = traderCount;
            UserCount = userCount;
            CreateDate = createDate;
            LastPing = lastPing;
            State = state;
            Exchanges = exchanges;
            Payment = payment;
            Logo = logo;
            Tariff = tariff;
            DefaultLanguage = defaultLanguage;
            Languages = languages;
            DayFee = dayFee;
            AdminTelegram = adminTelegram;
            AdminTelegramId = adminTelegramId;
        }

    }






















    public enum ProjectTariff
    {
        Start = 1,
        Company = 2,

    }

    public enum ProjectState
    {
        NewProjectRequest,
        Creating,
        CreatingFailure,
        Ready,
        Deleted,
        Frozen,
        DeleteProjectRequest,
        DeletingFailure,
        FrozenByAdmin,
        ChangeStateProcess,
        ChangeStateError,
        SourceRelocateRequest,
        DestinationRelocateRequest,
        RelocateSucceed,
        FrozenByOwner,
        FullDeleteProjectRequest
    }

    public enum ExchangeMarket
    {
        None = 0,
        Binance = 10,
        BingX = 90,
        Bitget = 80,
        Bybit = 20,
        
        
        
        Kucoin = 60,
        Okex = 70,
    }
}
