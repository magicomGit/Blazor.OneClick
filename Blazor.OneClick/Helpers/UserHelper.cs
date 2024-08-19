using Blazor.OneClick.Constants;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blazor.OneClick.Helpers
{
    public static class UserHelper
    {
        public static bool CheckIsAdmin(AuthenticationState authState)
        {
            if (authState == null)
            {
                return false;
            }

            if (authState.User.IsInRole(Settings.AdminRole))
            {
                return true;
            }
            return false;
        }

    }
}
