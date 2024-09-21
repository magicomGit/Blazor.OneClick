using OneClick.Data.Data;
using OneClick.Domain.Enums.Customer;

namespace Blazor.OneClick.Models
{
    public class UserData
    {
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? Avatar { get; set; }
        public string? Language { get; set; }
        public double Balance { get; set; }
        public DateTime? FreezeDay { get; set; }
        public UserTheme Theme { get; set; }
    }
}
