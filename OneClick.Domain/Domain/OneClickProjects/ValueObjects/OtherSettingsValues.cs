

using CSharpFunctionalExtensions;
using OneClick.Domain.Domain.DomainModels;
using OneClick.Domain.Enums.Project;

namespace OneClick.Domain.Domain.OneClickProjects.ValueObjects
{
    public class OtherSettingsValues : ValueObject
    {
        public bool BillingEnabled { get; }
        public bool CrossTradingEnabled { get; }


        private OtherSettingsValues(bool BillingEnabled, bool CrossTradingEnabled)
        {
            this.BillingEnabled = BillingEnabled;
            this.CrossTradingEnabled = CrossTradingEnabled;
        }
        private OtherSettingsValues() { }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }



        public static Response<OtherSettingsValues> Create(List<OtherSettings> settings)
        {
            var response = new Response<OtherSettingsValues> { Success = true };

            bool BillingEnabled = false;
            bool CrossTradingEnabled = false;

            foreach (var item in settings)
            {

                switch (item)
                {
                    case OtherSettings.Billing:
                        BillingEnabled = true; break;
                    case OtherSettings.CrossTrading:
                        CrossTradingEnabled = true; break;
                    default:
                        break;
                }
            }

            response.Data = new OtherSettingsValues(BillingEnabled, CrossTradingEnabled);
            return response;
        }


    }
}
