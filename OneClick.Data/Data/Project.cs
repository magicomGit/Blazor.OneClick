using Newtonsoft.Json;
using OneClick.Data.Enums;
using OneClick.Domain.Domain.OneClickProjects.ValueObjects;
using OneClick.Domain.Enums.Project;


namespace OneClick.Data.Data
{
    public class Project
    {
        public int Id { get; set; }
        public Guid OwnerId { get; set; }
        public string? OwnerName { get; set; }
        public string? ProjectDomain { get; set; }
        public string? ProjectName { get; set; }
        public string? ServerIP { get; set; }
        public string? ServerName { get; set; }
        public int TraderMaxCount { get; set; }
        public int UserMaxCount { get; set; }
        public int TraderCount { get; set; }
        public int UserCount { get; set; }
        public int ProxyCount { get; set; }
        public int AdminCount { get; set; }
        public string? ProjectConfig { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Description { get; set; }
        public ProjectState State { get; set; }
        public int ProjectErrorCode { get; set; }
        public ProjectTaskState ProjectWorkerTask { get; set; }
        public int IsRun { get; set; }
        public int ProcessId { get; set; }
        public DateTime StartEngineDate { get; set; }
        public DateTime StopEngineDate { get; set; }
        public DateTime LastPing { get; set; }
        public string? WWWrootVersion { get; set; }
        public string? EngineVersion { get; set; }
        public bool Synchronized { get; set; }
        public virtual Payment? Payment { get; set; }
        public string? TelegramBot { get; set; }
        public string? TelegramKey { get; set; }


        public void SetProjectConfig(ProjectConfig config)
        {
            try
            {
                ProjectConfig = JsonConvert.SerializeObject(config, Formatting.Indented);
            }
            catch (Exception ex)
            {

            }
        }
        public ProjectConfig GetProjectConfig()
        {
            try
            {
                return JsonConvert.DeserializeObject<ProjectConfig>(ProjectConfig);
            }
            catch (Exception ex)
            {
                return new ProjectConfig();
            }
        }
    }


    public class ProjectConfig
    {
        public string? SystemName { get; set; }
        public string? TelegramName { get; set; }
        public string? TelegramKey { get; set; }
        public List<ExchangeMarket>? Exchanges { get; set; }
        public string? DefaultLanguage { get; set; }
        public bool IsCrossTrading { get; set; }
        public bool HideCopyright { get; set; }
        public bool EnablePayment { get; set; }
        public bool EnableBilling { get; set; }
        public List<Language>? Languages { get; set; }
        public List<string>? IPsWL { get; set; }
        public bool EnableAffiliateNets { get; set; }
        public bool IsCrossPlatformTradingAllowed { get; set; }
        public string? UrlLogo { get; set; }
        public ProjectTariff Tariff { get; set; } = ProjectTariff.Start;
        public int MaxExchangeRequestInOneMinute { get; set; }
        public int MaxExchangeRequestInFiveMinutes { get; set; }
        public string? AdminTelegram { get; set; }
        public long AdminTelegramId { get; set; }
    }

}
