using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OneClick.Data.Data;
using OneClick.Domain.Domain.DomainServices;
using OneClick.UseCases.Intefaces.App;
using static OneClick.Domain.Enums.App.AppEnums;

namespace OneClick.Data.Repositoties
{
    public class AppSettingsRepository : IAppSettingsRepository
    {
        private ApplicationDbContext _context;
        public AppSettingsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServicesPrice> GetServicesPrices()
        {
            var priceJson = await _context.Settings.Where(x => x.Name == SettingsNames.ServicesPrice).Select(s => s.JsonObject).FirstOrDefaultAsync();

            if (priceJson == null)
            {
                await _context.Settings.AddAsync(new SystemSettings { Name = SettingsNames.ServicesPrice, JsonObject = GetPriceJson(new ServicesPrice()) });
                await _context.SaveChangesAsync();

                priceJson = await _context.Settings.Where(x => x.Name == SettingsNames.ServicesPrice).Select(s => s.JsonObject).FirstOrDefaultAsync();
                //log
            }

            var price = new ServicesPrice();

            try
            {
                price = JsonConvert.DeserializeObject<ServicesPrice>(priceJson);

            }
            catch (Exception)
            {

                return null;
            }

            return price;
        }


        
        public async Task<AppSettings> GetAppSettings()
        {
            var appSettingsJson = await _context.Settings.Where(x => x.Name == SettingsNames.AppSettings).Select(s => s.JsonObject).FirstOrDefaultAsync();

            if (appSettingsJson == null)
            {
                await _context.Settings.AddAsync(new SystemSettings { Name = SettingsNames.AppSettings, JsonObject = GetAppSettingsJson(new AppSettings()) });
                await _context.SaveChangesAsync();

                appSettingsJson = _context.Settings.Where(x => x.Name == SettingsNames.AppSettings).Select(s => s.JsonObject).FirstOrDefault();
                //log
            }


            var appSettings = new AppSettings();
            try
            {
                appSettings = JsonConvert.DeserializeObject<AppSettings>(appSettingsJson);

            }
            catch (Exception)
            {
                return null;
            }

           

            return appSettings;
        }


        public async Task<string> GetDefaultAvatar()
        {
            var defaultAvatar = await  _context.Settings.Where(x => x.Name == SettingsNames.DefaultAvatar).Select(s => s.JsonObject).FirstOrDefaultAsync();
            if (!string.IsNullOrEmpty(defaultAvatar))
            {
                return defaultAvatar;
            }
            else
            {
                return "";
            }
        }
        
        public async Task<string> GetSystemLogo()
        {
            var systemLogo = await  _context.Settings.Where(x => x.Name == SettingsNames.SystemLogo).Select(s => s.JsonObject).FirstOrDefaultAsync();
            if (!string.IsNullOrEmpty(systemLogo))
            {
                return systemLogo;
            }
            else
            {
                return "";
            }
        }

        //================= private methods ========================
        private static string GetPriceJson(ServicesPrice price)
        {
            return JsonConvert.SerializeObject(price, Formatting.Indented);
        }

        public static string GetAppSettingsJson(AppSettings price)
        {

            return JsonConvert.SerializeObject(price, Formatting.Indented);
        }

        
    }
}
