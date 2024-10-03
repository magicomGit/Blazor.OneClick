using OneClick.Domain.Domain.Customers;
using OneClick.Domain.Enums.Customer;

namespace OneClick.UseCases.Intefaces.User
{
    public interface IUserRepository
    {
        Task<Customer> GetByNameAsync(string name, bool requireBalnce = true, bool requirePayment = true, bool requireAlerts = true);
        Task<Customer> GetByIdAsync(string id, bool requireBalnce = true, bool requirePayment = true, bool requireAlerts = true);

        Task<bool> UpdateThemeAsync(string userId, UserTheme theme);
        Task<bool> UpdateBalanceAsync(Customer user);
    }
}
