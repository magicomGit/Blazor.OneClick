using CloudFlare.Client.Client.Users;
using OneClick.Data.Data;
using OneClick.UseCases.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OneClick.Data.Builreds
{
    public class AppUserExpressionBuiler
    {
        public static Expression<Func<ApplicationUser, object>> Build(AppUserSortBy sortBy)
        {
            Expression<Func<ApplicationUser, object>> expression = x => x.Registered;
            var sortByStr = sortBy.ToString();

            switch (sortBy)
            {
                case AppUserSortBy.UserName:
                     expression = x => x.UserName;
                    return expression;
                    
                case AppUserSortBy.Telegram:
                     expression = x => x.Telegram;
                    return expression;

                case AppUserSortBy.Status:
                    expression = x => x.Status;
                    return expression;

                case AppUserSortBy.WalletBalance:
                    expression = x => x.Balance.WalletBalance;
                    return expression;

                case AppUserSortBy.Registered:
                    expression = x => x.Registered;
                    return expression;
                default:
                    return expression;
            }
        }
    }

   
}
