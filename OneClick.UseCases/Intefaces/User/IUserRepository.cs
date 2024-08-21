﻿using OneClick.Domain.Domain.Customers;
using OneClick.Domain.Enums.Customer;

namespace OneClick.UseCases.Intefaces.User
{
    public interface IUserRepository
    {
        Task<Customer> GetUserByNameAsync(string name, bool requireBalnce = true, bool requirePayment = true, bool requireAlerts = true);

        Task<int> UpdateThemeAsync(string userId, UserTheme theme);
    }
}