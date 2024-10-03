using OneClick.Data.Data;
using OneClick.Domain.Domain.Customers;

namespace OneClick.Data.Dto
{
    public class CustomerDto
    {
        public static List<Alert> AlertDto(List<CustomerAlert> alerts)
        {
            var alerts_ = new List<Alert>();
            foreach (var alert in alerts)
            {
                alerts_.Add(new Alert
                {
                    Id = alert.Id,
                    DisposeTime = alert.DisposeTime,
                    Issuer = alert.Issuer,
                    Link = alert.Link,
                    Message = alert.Message,
                    NotificationCount = alert.NotificationCount,
                    Severity = alert.Severity,

                });
            }

            return alerts_;
        }
        
        public static Balance BalanceDto(CustomerBalance b)
        {
            var balance = new Balance { 
            Id = b.Id,
            Network = b.Network,
            WalletAddress = b.WalletAddress,
            WalletBalance = b.WalletBalance,
            AwaitTransaction = b.AwaitTransaction
            };




            return balance;
        }


        //public static ApplicationUser Dto(Customer user)
        //{
        //    var alerts = AlertDto(user.Alerts ?? []);

        //    var user_ = new ApplicationUser();
        //    user_.UserName = user.UserName;
        //    user_.Avatar = user.Avatar;
        //    user_.Alerts = alerts;
        //    user_.EmailConfirmed = user.Em
        //}
    }
}
