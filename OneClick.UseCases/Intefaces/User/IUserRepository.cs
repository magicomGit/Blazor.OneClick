using OneClick.Domain.Domain.Customers;
using OneClick.Domain.Enums.Customer;
using OneClick.UseCases.Enums;

namespace OneClick.UseCases.Intefaces.User
{
    public interface IUserRepository
    {
        Task<Customer> GetByNameAsync(string name, bool requireBalnce = true, bool requirePayment = true, bool requireAlerts = true);
        Task<Customer> GetByIdAsync(string id, bool requireBalnce = true, bool requirePayment = true, bool requireAlerts = true);
        Task<List<Customer>> GetAsync(bool requireBalnce = true, bool requirePayment = true, bool requireAlerts = true);
        Task<List<Customer>> GetPageAsync(int page, int ItemsPerPage, AppUserSortBy sortBy = AppUserSortBy.Registered, bool desc = false,
            bool requireBalnce = true, bool requirePayment = true, bool requireAlerts = true);

        Task<bool> UpdateThemeAsync(string userId, UserTheme theme);
        Task<bool> UpdateBalanceAsync(Customer user);
        Task<double> GetWalletBalanceAsync(string userId);
    }
}
