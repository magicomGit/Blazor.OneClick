using Microsoft.EntityFrameworkCore;
using OneClick.Data.Data;
using OneClick.Data.Dto;
using OneClick.Domain.Domain.Customers;
using OneClick.Domain.Enums.Customer;
using OneClick.UseCases.Intefaces.User;

namespace OneClick.Data.Repositoties
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetByNameAsync(string name, bool requireBalnce = true, bool requirePayment = true, bool requireAlerts = true)
        {

            var customerPayment = new CustomerPayment();
            var customerBalance = new CustomerBalance();
            var customerAlerts = new List<CustomerAlert>();

            var userQuery = _context.Users.Where(x => x.UserName == name).AsNoTracking();

            if (requireBalnce)
            {
                userQuery = userQuery.Include(x => x.Balance);
            }

            if (requirePayment)
            {
                userQuery = userQuery.Include(x => x.PaymentInfo);
            }

            if (requireAlerts)
            {
                userQuery = userQuery.Include(x => x.Alerts);
            }

            var user = await userQuery.FirstOrDefaultAsync();


            if (user == null) { return null; }

            if (requireBalnce)
            {
                customerBalance = new CustomerBalance
                {
                    Id = user.Balance.Id,
                    Network = user.Balance.Network,
                    WalletAddress = user.Balance.WalletAddress,
                    WalletBalance = user.Balance.WalletBalance,
                };
            }


            if (requirePayment)
            {
                customerPayment = new CustomerPayment
                {
                    Id = user.PaymentInfo.Id,
                    Price = user.PaymentInfo.Price,
                    LastPayment = user.PaymentInfo.LastPayment,
                    Description = user.PaymentInfo.Description,
                };
            }


            if (requireAlerts)
            {
                user.Alerts.ForEach(x => customerAlerts.Add(new CustomerAlert
                {
                    Id = x.Id,
                    DisposeTime = x.DisposeTime,
                    Issuer = x.Issuer,
                    Link = x.Link,
                    Message = x.Message,
                    NotificationCount = x.NotificationCount,
                    Severity = x.Severity,
                    Time = x.DisposeTime
                }));
            }






            var customer = new Customer(user.Id, user.UserName, user.TelegramId, user.Telegram, user.FirstName, user.Phone, user.Email, user.Avatar, customerAlerts,
                customerBalance, user.Registered, user.LastActivity, customerPayment, user.Language, user.Theme);

            return customer;
        }


        public async Task<Customer> GetByIdAsync(string id, bool requireBalnce = true, bool requirePayment = true, bool requireAlerts = true)
        {

            var customerPayment = new CustomerPayment();
            var customerBalance = new CustomerBalance();
            var customerAlerts = new List<CustomerAlert>();

            var userQuery = _context.Users.Where(x => x.Id == id).Include(x => x.Balance).Include(x => x.PaymentInfo).AsNoTracking();

            //if (requireBalnce)
            //{
            //    userQuery = userQuery.Include(x => x.Balance);
            //}

            //if (requirePayment)
            //{
            //    userQuery = userQuery.Include(x => x.PaymentInfo);
            //}

            //if (requireAlerts)
            //{
            //    userQuery = userQuery.Include(x => x.Alerts);
            //}

            var user = await userQuery.FirstOrDefaultAsync();


            if (user == null) { return null; }

            if (requireBalnce)
            {
                customerBalance = new CustomerBalance
                {
                    Id = user.Balance.Id,
                    Network = user.Balance.Network,
                    WalletAddress = user.Balance.WalletAddress,
                    WalletBalance = user.Balance.WalletBalance,
                };
            }


            if (requirePayment)
            {
                customerPayment = new CustomerPayment
                {
                    Id = user.PaymentInfo.Id,
                    Price = user.PaymentInfo.Price,
                    LastPayment = user.PaymentInfo.LastPayment,
                    Description = user.PaymentInfo.Description,
                };
            }


            if (requireAlerts)
            {
                user.Alerts.ForEach(x => customerAlerts.Add(new CustomerAlert
                {
                    Id = x.Id,
                    DisposeTime = x.DisposeTime,
                    Issuer = x.Issuer,
                    Link = x.Link,
                    Message = x.Message,
                    NotificationCount = x.NotificationCount,
                    Severity = x.Severity,
                    Time = x.DisposeTime
                }));
            }






            var customer = new Customer(user.Id, user.UserName, user.TelegramId, user.Telegram, user.FirstName, user.Phone, user.Email, user.Avatar, customerAlerts,
                customerBalance, user.Registered, user.LastActivity, customerPayment, user.Language, user.Theme);

            return customer;
        }

        public async Task<bool> UpdateThemeAsync(string userId, UserTheme theme)
        {
            await _context.Users.Where(x => x.Id == userId).ExecuteUpdateAsync(e => e.SetProperty(x => x.Theme, theme));

            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public async Task<bool> UpdateBalanceAsync(Customer user)
        {
            await _context.Users.Where(x => x.Id == user.Id).ExecuteUpdateAsync(e => e
            .SetProperty(x => x.Balance, CustomerDto.BalanceDto(user.Balance)));

           var result =  await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
