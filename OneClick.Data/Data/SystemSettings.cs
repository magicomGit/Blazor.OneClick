using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OneClick.Domain.Enums.App.AppEnums;

namespace OneClick.Data.Data
{
    public class SystemSettings
    {
        public int Id { get; set; }
        public AppSettings Name { get; set; }
        public string? JsonObject { get; set; }
    }
}
