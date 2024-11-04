using OneClick.Domain.Domain.Balances;
using OneClick.Domain.Domain.DomainModels;
using OneClick.Domain.Domain.OneClickProjects;
using OneClick.Domain.Enums.Project;
using OneClick.Services.Helpers;
using OneClick.UseCases.Intefaces.App;
using OneClick.UseCases.Intefaces.Balances;

namespace OneClick.Services.Balances
{

    public class InvoiceService : IInvoiceService<Response<OneClickInvoice>, CopyTradingProject>
    {
        private readonly IAppSettingsRepository _settingsRepository;

        public InvoiceService(IAppSettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public async Task<Response<OneClickInvoice>> EditProjectInvoice(CopyTradingProject newProject, CopyTradingProject currentProject, ProjectTariff tariff)
        {
            var response = new Response<OneClickInvoice> { Success = true };

            var servicesPrice = await _settingsRepository.GetServicesPrices();
            var tariffPrice = SettingsHelper.GetTariffPrices(currentProject.Tariff, servicesPrice);

            var addInvoiceItems = new List<OneClickInvoiceItem>();
            var returmInvoiceItems = new List<OneClickInvoiceItem>();

            var invoice = new OneClickInvoice
            {
                Name = "Edit project",
                Date = DateTime.UtcNow,
                UserId = currentProject.Owner.Id,
                UserName = currentProject.Owner.Name,
            };

            //crosstarding
            if (!currentProject.OtherSettings.CrossTradingEnabled)
            {
                if (newProject.OtherSettings.CrossTradingEnabled)
                {
                    addInvoiceItems.Add(new OneClickInvoiceItem
                    {
                        Name = "AddCrossTrading",
                        Price = tariffPrice.CrossTradingRate,
                        Sum = tariffPrice.CrossTradingRate
                    });
                }
            }
            //BillingEnabled
            if (!currentProject.OtherSettings.BillingEnabled)
            {
                if (newProject.OtherSettings.BillingEnabled)
                {
                    addInvoiceItems.Add(new OneClickInvoiceItem
                    {
                        Name = "AddBilling",
                        Price = tariffPrice.BillingRate,
                        Sum = tariffPrice.BillingRate
                    });
                }
            }



            //Binance
            if (!currentProject.Exchanges.BinanceEnabled)
            {
                if (newProject.Exchanges.BinanceEnabled)
                {
                    addInvoiceItems.Add(new OneClickInvoiceItem
                    {
                        Name = "AddExchange" + " Binance",
                        Price = tariffPrice.ExchangeRate,
                        Sum = tariffPrice.ExchangeRate
                    });
                }
            }

            //Bitget
            if (!currentProject.Exchanges.BitgetEnabled)
            {
                if (newProject.Exchanges.BitgetEnabled)
                {
                    addInvoiceItems.Add(new OneClickInvoiceItem
                    {
                        Name = "AddExchange" + " Bitget",
                        Price = tariffPrice.ExchangeRate,
                        Sum = tariffPrice.ExchangeRate
                    });
                }
            }


            //Bybit
            if (!currentProject.Exchanges.BybitEnabled)
            {
                if (newProject.Exchanges.BybitEnabled)
                {
                    addInvoiceItems.Add(new OneClickInvoiceItem
                    {
                        Name = "AddExchange" + " Bybit",
                        Price = tariffPrice.ExchangeRate,
                        Sum = tariffPrice.ExchangeRate
                    });
                }
            }


            //Kucoin
            if (!currentProject.Exchanges.KucoinEnabled)
            {
                if (newProject.Exchanges.KucoinEnabled)
                {
                    addInvoiceItems.Add(new OneClickInvoiceItem
                    {
                        Name = "AddExchange" + " Kucoin",
                        Price = tariffPrice.ExchangeRate,
                        Sum = tariffPrice.ExchangeRate
                    });
                }
            }

            //OKX
            if (!currentProject.Exchanges.OkxEnabled)
            {
                if (newProject.Exchanges.OkxEnabled)
                {
                    addInvoiceItems.Add(new OneClickInvoiceItem
                    {
                        Name = "AddExchange" + " OKX",
                        Price = tariffPrice.ExchangeRate,
                        Sum = tariffPrice.ExchangeRate
                    });
                }
            }

            //BingX
            if (!currentProject.Exchanges.BingxEnabled)
            {
                if (newProject.Exchanges.BingxEnabled)
                {
                    addInvoiceItems.Add(new OneClickInvoiceItem
                    {
                        Name = "AddExchange" + " BingX",
                        Price = tariffPrice.ExchangeRate,
                        Sum = tariffPrice.ExchangeRate
                    });
                }
            }

            //--------------------


            invoice.Items.AddRange(addInvoiceItems);
            invoice.Items.AddRange(returmInvoiceItems);
            invoice.Price += addInvoiceItems.Sum(x => x.Sum);
            invoice.Price += returmInvoiceItems.Sum(x => x.Sum);
            invoice.Price = invoice.Price;

            response.Data = invoice;



            return response;
        }
    }
}
