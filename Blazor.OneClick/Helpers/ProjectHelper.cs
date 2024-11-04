using Blazor.OneClick.Constants;
using Blazor.OneClick.Models;
using OneClick.Domain.Domain.OneClickProjects;
using static Blazor.OneClick.Constants.Enums;

namespace Blazor.OneClick.Helpers
{
    public static class ProjectHelper
    {
        public static EditProjectSettings FillEditProjectSettings(CopyTradingProject prject)
        {

            var exchanges = new List<ExchangeMarket>();

            if (prject.Exchanges.BinanceEnabled)
            { exchanges.Add(ExchangeMarket.Binance); }

            if (prject.Exchanges.BybitEnabled)
            { exchanges.Add(ExchangeMarket.Bybit); }

            if (prject.Exchanges.BitgetEnabled)
            { exchanges.Add(ExchangeMarket.Bitget); }

            if (prject.Exchanges.KucoinEnabled)
            { exchanges.Add(ExchangeMarket.Kucoin); }

            if (prject.Exchanges.OkxEnabled)
            { exchanges.Add(ExchangeMarket.OKX); }

            if (prject.Exchanges.BingxEnabled)
            { exchanges.Add(ExchangeMarket.Bingx); }




            var projectSettings = new EditProjectSettings
            {
                ProjectName = prject.ProjectName,
                EnableBilling = prject.OtherSettings.BillingEnabled,
                Exchanges = exchanges,
                IsCrossTrading = prject.OtherSettings.CrossTradingEnabled,
                OwnerId = prject.Owner.Id,
                ServerIP = prject.Server.ServerIP,
                TraderMaxCount = Settings.TraderMaxForProject,
                UserMaxCount = Settings.InvestorMaxForProject,
                DefaultLanguage = prject?.DefaultLanguage,
                Languages = prject?.Languages?.Select(s => new Language { code = s.Code , name = s.Name} ).ToList(),
            };



            return projectSettings;
        }
    }
}
