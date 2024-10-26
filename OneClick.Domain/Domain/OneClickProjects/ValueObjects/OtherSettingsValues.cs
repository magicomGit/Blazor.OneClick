

using CSharpFunctionalExtensions;
using OneClick.Domain.Domain.DomainModels;

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



        public static Response<OtherSettingsValues> Create(bool billingEnabled, bool crossTradingEnabled)
        {
            var response = new Response<OtherSettingsValues> { Success = true };
            response.Data = new OtherSettingsValues(billingEnabled, crossTradingEnabled);
            return response;
        }


    }
}
