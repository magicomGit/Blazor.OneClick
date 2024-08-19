using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClick.Domain.Domain.OneClickProjects
{
    public class TariffPrices
    {
        public double ExchangeRate { get; set; }
        public double CrossTradingRate { get; set; }
        public double BillingRate { get; set; }
        public double TraderRate { get; set; }
        public double TraderRateDaily { get; set; }
        public double UserRate { get; set; }
        public double UserRateDaily { get; set; }
        public double CreateProjectRate { get; set; }
        public double AddDomainRate { get; set; }
        public int MaxExchangeRequestInOneMinute { get; set; }
        public int MaxExchangeRequestInFiveMinutes { get; set; }
    }
}
