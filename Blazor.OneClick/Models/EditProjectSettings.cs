using static Blazor.OneClick.Constants.Enums;

namespace Blazor.OneClick.Models
{
    public class EditProjectSettings
    {
        public string? ProjectName { get; set; }
        public Guid OwnerId { get; set; }
        public int TraderMaxCount { get; set; }
        public int UserMaxCount { get; set; }
        public List<ExchangeMarket>? Exchanges { get; set; }
        public List<Language>? Languages { get; set; }
        public string? DefaultLanguage { get; set; }
        public bool IsCrossTrading { get; set; }
        public bool EnableBilling { get; set; }
        public string? ServerIP { get; set; }
    }
}
