using static OneClick.Domain.Enums.App.AppEnums;

namespace OneClick.Data.Data
{
    public class SystemSettings
    {
        public int Id { get; set; }
        public SettingsNames Name { get; set; }
        public string? JsonObject { get; set; }
    }
}
