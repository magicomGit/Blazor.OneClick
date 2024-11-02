using Microsoft.EntityFrameworkCore;
using OneClick.Data.Data;
using OneClick.Data.Dto;
using OneClick.Data.Factories;
using OneClick.Domain.Domain.Customers;
using OneClick.Domain.Enums.Customer;
using OneClick.UseCases.Enums;
using OneClick.UseCases.Intefaces.App;
using OneClick.UseCases.Intefaces.User;

namespace OneClick.Data.Repositoties
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;
        private IAppLogger _logger;
        public UserRepository(ApplicationDbContext context, IAppLogger logger)
        {
            _context = context;
            _logger = logger;
        }



        public async Task<List<Customer>> GetPageAsync(int page = 1, int ItemsPerPage = 15, AppUserSortBy sortBy = AppUserSortBy.Registered, bool desc = false,
            bool requireBalnce = true, bool requirePayment = true, bool requireAlerts = true)
        {
            var customers = new List<Customer>();

            var expression = AppUserExpressionFactory.Build(sortBy);

            var userQuery = _context.Users.AsNoTracking();
            if (desc)
            {
                userQuery = userQuery.OrderByDescending(expression).Skip(ItemsPerPage * (page - 1)).Take(ItemsPerPage);
            }
            else
            {
                userQuery = userQuery.OrderBy(expression).Skip(ItemsPerPage * (page - 1)).Take(ItemsPerPage);
            }

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

            var users = await userQuery.ToListAsync();
            //---------------------------------------
            customers = DTO(users, requireBalnce, requirePayment, requireAlerts);



            return customers;
        }
        public async Task<List<Customer>> GetAsync(bool requireBalnce = true, bool requirePayment = true, bool requireAlerts = true)
        {

            var customers = new List<Customer>();


            var userQuery = _context.Users.AsNoTracking();

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

            var users = await userQuery.ToListAsync();

            if (users == null) { return customers; }

            customers = DTO(users, requireBalnce, requirePayment, requireAlerts);



            return customers;
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

        //=================== private methods ================
        private List<Customer> DTO(List<ApplicationUser> users, bool requireBalnce, bool requirePayment, bool requireAlerts)
        {
            var customers = new List<Customer>();
            var customerPayment = new CustomerPayment();
            var customerBalance = new CustomerBalance();
            var customerAlerts = new List<CustomerAlert>();

            foreach (var user in users)
            {
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
                    if (user.PaymentInfo is null)
                    {

                        _logger.LogError($"User Id: {user.Id} | Не удалсь загрузить информацию платежах");
                    }
                    else
                    {
                        customerPayment = new CustomerPayment
                        {
                            Id = user.PaymentInfo.Id,
                            Price = user.PaymentInfo.Price,
                            LastPayment = user.PaymentInfo.LastPayment,
                            Description = user.PaymentInfo.Description,
                        };
                    }
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

                customers.Add(customer);
            }


            return customers;
        }
    }
}
