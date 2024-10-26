using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OneClick.Data.Constants;
using OneClick.Data.Data;
using OneClick.Domain.Domain.DomainModels;
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
            var defaultAvatar = await _context.Settings.Where(x => x.Name == SettingsNames.DefaultAvatar).Select(s => s.JsonObject).FirstOrDefaultAsync();
            if (!string.IsNullOrEmpty(defaultAvatar))
            {
                return defaultAvatar;
            }
            else
            {
                return DefaultAvatar.Content;
            }
        }

        public async Task<string> GetSystemLogo()
        {
            var systemLogo = await _context.Settings.Where(x => x.Name == SettingsNames.SystemLogo).Select(s => s.JsonObject).FirstOrDefaultAsync();
            if (!string.IsNullOrEmpty(systemLogo))
            {
                return systemLogo;
            }
            else
            {
                return SystemLogo.Content;
            }
        }

        public async Task<string> GetAdminId()
        {
            var settingsAdminId = await _context.Settings.Where(x => x.Name == SettingsNames.AdminId).FirstOrDefaultAsync();
            var adminId = string.Empty;
            if (settingsAdminId != null)
            {
                adminId = settingsAdminId.JsonObject;
                if (adminId == "")
                {
                    var admin = await _context.Users.Where(x => x.UserName == "admin").FirstOrDefaultAsync();
                    if (admin != null)
                    {
                        settingsAdminId.JsonObject = admin.Id;
                        _context.Update(settingsAdminId);
                        await _context.SaveChangesAsync();

                        adminId = admin.Id;
                    }
                }
            }
            else
            {
                var admin = await _context.Users.Where(x => x.UserName == "admin").FirstOrDefaultAsync();
                if (admin != null)
                {
                    await _context.Settings.AddAsync(new SystemSettings { Name = SettingsNames.AdminId, JsonObject = admin.Id });
                    adminId = admin.Id;
                }
                else
                {
                    await _context.Settings.AddAsync(new SystemSettings { Name = SettingsNames.AdminId, JsonObject = "" });
                }
                await _context.SaveChangesAsync();
            }
            return adminId;
        }

        public async Task<BillingSettings> GetBillingSettings()
        {
            var billingSettingsJson = await _context.Settings.Where(x => x.Name == SettingsNames.BillingSettings).Select(s => s.JsonObject).FirstOrDefaultAsync();

            if (billingSettingsJson == null)
            {
                await _context.Settings.AddAsync(new SystemSettings
                { Name = SettingsNames.BillingSettings, JsonObject = GetBillingSettingsJson(new BillingSettings()) });
                await _context.SaveChangesAsync();

                billingSettingsJson = await _context.Settings.Where(x => x.Name == SettingsNames.BillingSettings).Select(s => s.JsonObject).FirstOrDefaultAsync();
                //log
            }

            var billingSettings = new BillingSettings();

            try
            {
                billingSettings = JsonConvert.DeserializeObject<BillingSettings>(billingSettingsJson);
            }
            catch (Exception)
            {
                return null;
            }

            return billingSettings;
        }

        public async Task<bool> SaveBillingSettings(BillingSettings settings)
        {
            var settingJson = JsonConvert.SerializeObject(settings, Formatting.Indented);

            var billingSettings = await _context.Settings.Where(x => x.Name == SettingsNames.BillingSettings).FirstOrDefaultAsync();

            if (billingSettings != null)
            {
                try
                {
                    billingSettings.JsonObject = settingJson;
                    var saveResult = _context.Update(billingSettings);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return false;
                }


            }



            return true;
        }



        public async Task<bool> SaveAppSettings(AppSettings settings)
        {
            var settingJson = JsonConvert.SerializeObject(settings, Formatting.Indented);

            var oldSettings = await _context.Settings.Where(x => x.Name == SettingsNames.AppSettings).FirstOrDefaultAsync();

            if (oldSettings != null)
            {
                try
                {
                    oldSettings.JsonObject = settingJson;
                    var saveResult = _context.Update(oldSettings);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return false;
                }


            }

            return true;
        }



        public async Task<bool> SaveServicesPrices(ServicesPrice settings)
        {
            var settingJson = JsonConvert.SerializeObject(settings, Formatting.Indented);

            var oldSettings = await _context.Settings.Where(x => x.Name == SettingsNames.ServicesPrice).FirstOrDefaultAsync();

            if (oldSettings != null)
            {
                try
                {
                    oldSettings.JsonObject = settingJson;
                    var saveResult = _context.Update(oldSettings);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return false;
                }


            }



            return true;
        }
        
        public async Task<bool> SaveAvatar(string settings)
        {        
            var oldSettings = await _context.Settings.Where(x => x.Name == SettingsNames.DefaultAvatar).FirstOrDefaultAsync();

            if (oldSettings != null)
            {
                try
                {
                    oldSettings.JsonObject = settings;
                    var saveResult = _context.Update(oldSettings);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }
        
        public async Task<bool> SaveSystemLogo(string settings)
        {        
            var oldSettings = await _context.Settings.Where(x => x.Name == SettingsNames.SystemLogo).FirstOrDefaultAsync();

            if (oldSettings != null)
            {
                try
                {
                    oldSettings.JsonObject = settings;
                    var saveResult = _context.Update(oldSettings);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
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

        public static string GetBillingSettingsJson(BillingSettings obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }


    }
}
