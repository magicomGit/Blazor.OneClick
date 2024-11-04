using CSharpFunctionalExtensions;
using OneClick.Domain.Domain.DomainModels;
using OneClick.Domain.Enums.Project;

namespace OneClick.Domain.Domain.OneClickProjects.ValueObjects
{
    public class ExchangeValues : ValueObject
    {
        public bool BinanceEnabled { get; }
        public bool BitgetEnabled { get; }
        public bool BybitEnabled { get; }
        public bool BingxEnabled { get; }
        public bool KucoinEnabled { get; }
        public bool OkxEnabled { get; }


        private ExchangeValues(bool BinanceEnabled, bool BitgetEnabled, bool BybitEnabled, bool BingxEnabled, bool KucoinEnabled, bool OkxEnabled)
        {
            this.BinanceEnabled = BinanceEnabled;
            this.BitgetEnabled = BitgetEnabled;
            this.BybitEnabled = BybitEnabled;
            this.BingxEnabled = BingxEnabled;
            this.KucoinEnabled = KucoinEnabled;
            this.OkxEnabled = OkxEnabled;
        }
        private ExchangeValues() { }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }



        public static Response<ExchangeValues> Create(List<ExchangeMarket> exchanges)
        {
            var response = new Response<ExchangeValues> { Success = true };

            var BinanceEnabled = false;
            var BitgetEnabled = false;
            var BybitEnabled = false;
            var BingxEnabled = false;
            var KucoinEnabled = false;
            var OkxEnabled = false;

            foreach (var exchange in exchanges) {
                switch (exchange)
                {
                   
                    case ExchangeMarket.Binance:
                        BinanceEnabled = true;  break;
                    case ExchangeMarket.BingX:
                        BingxEnabled = true; break;
                    case ExchangeMarket.Bitget:
                        BitgetEnabled = true; break;
                    case ExchangeMarket.Bybit:
                        BybitEnabled = true; break;
                    case ExchangeMarket.Kucoin:
                        KucoinEnabled = true; break;
                    case ExchangeMarket.Okx:
                        OkxEnabled = true; break;
                    default:
                        break;
                }
            }



            response.Data = new ExchangeValues( BinanceEnabled,  BitgetEnabled,  BybitEnabled,  BingxEnabled,  KucoinEnabled,  OkxEnabled);
            return response;
        }


    }
    
}
