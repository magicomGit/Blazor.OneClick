using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OneClick.Data.Data;
using OneClick.Domain.Domain.DomainServices;
using OneClick.UseCases.Intefaces.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var priceJson = await _context.Settings.Where(x => x.Name == AppSettings.ServicesPrice).Select(s => s.JsonObject).FirstOrDefaultAsync();

            if (priceJson == null)
            {
                await _context.Settings.AddAsync(new SystemSettings { Name = AppSettings.ServicesPrice, JsonObject = GetPriceJson(new ServicesPrice()) });
                await _context.SaveChangesAsync();

                priceJson = await _context.Settings.Where(x => x.Name == AppSettings.ServicesPrice).Select(s => s.JsonObject).FirstOrDefaultAsync();
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


        private static string GetPriceJson(ServicesPrice price)
        {
            return JsonConvert.SerializeObject(price, Formatting.Indented);
        }
    }
}
