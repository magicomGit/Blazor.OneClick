using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClick.Domain.Domain.DomainServices
{
    public class ServicesPrice
    {
        public double ExchangeRate { get; set; }
        public double CrossTradingRate { get; set; }
        public double BillingRate { get; set; }
        public double TraderRate { get; set; }
        public double UserRate { get; set; }
        public double CreateProjectRate { get; set; }
        public double AddDomainRate { get; set; }
        public int MaxExchangeRequestInOneMinute { get; set; }
        public int MaxExchangeRequestInFiveMinutes { get; set; }


        public double ExchangeRate2 { get; set; }
        public double CrossTradingRate2 { get; set; }
        public double BillingRate2 { get; set; }
        public double TraderRate2 { get; set; }
        public double UserRate2 { get; set; }
        public double CreateProjectRate2 { get; set; }

        public double AddDomainRate2 { get; set; }
        public int MaxExchangeRequestInOneMinute2 { get; set; }
        public int MaxExchangeRequestInFiveMinutes2 { get; set; }
    }
}
