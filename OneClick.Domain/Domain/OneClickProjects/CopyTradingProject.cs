using OneClick.Domain.Domain.OneClickProjects.ValueObjects;
using OneClick.Domain.Enums.Project;

namespace OneClick.Domain.Domain.OneClickProjects
{
    public class CopyTradingProject
    {
        public int Id { get; set; }       
        public Owner Owner { get; }
        public ServerInfo Server { get; }
        public string? ProjectDomain { get; set; }
        public TelegramBot TelegramBot { get; }        
        public string? ProjectName { get; set; }
       
        public int ProxyCount { get; set; }
        public int TraderMaxCount { get; set; }

        public int UserMaxCount { get; set; }
        public int TraderCount { get; set; }
        public int UserCount { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastPing { get; set; }
        public ProjectState State { get; set; }

        public ExchangeValues Exchanges { get; private set; }
        public OtherSettingsValues OtherSettings { get; private set; }
       
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
        public CopyTradingProject(int id, string projectDomain, TelegramBot telegramBot, string projectName,
            string serverIP, string serverName, int serverId, int proxyCount, int traderMaxCount, int userMaxCount, int traderCount, int userCount,
            DateTime createDate, DateTime lastPing, ProjectState state, ExchangeValues exchanges, ProjectPayment payment, string logo,
            ProjectTariff tariff, string defaultLanguage, List<Language> languages, double dayFee, string adminTelegram, long adminTelegramId,
            OtherSettingsValues otherSettings, Owner owner, ServerInfo server)
        {
            Id = id;
            Owner = owner;
            
            ProjectDomain = projectDomain;
            TelegramBot = telegramBot;
            ProjectName = projectName;
            Server = server;
           
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
            OtherSettings = otherSettings;
        }

        public void SetExchangeValues(List<ExchangeMarket> exchanges)
        {
            var exchangesResult = ExchangeValues.Create(exchanges);
            if (exchangesResult.Success)
            {
                Exchanges = exchangesResult.Data;
            }
        }
        
        public void SetSettingsValues(List<OtherSettings> settings)
        {
            var exchangesResult = OtherSettingsValues.Create(settings);
            if (exchangesResult.Success)
            {
                OtherSettings = exchangesResult.Data;
            }
        }

    }


    
}
