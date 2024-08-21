using Newtonsoft.Json;
using OneClick.Data.Data;
using OneClick.Data.Enums;
using OneClick.Domain.Domain.OneClickProjects;
using OneClick.Domain.Enums.Customer;

namespace OneClick.Data.Dto
{
    public class OneClickProjectDto
    {
        public static ProjectPayment PaymentDto(Payment payment)
        {

            if (payment == null)
            {
                return new ProjectPayment();
            }

            var projectPayment =  new ProjectPayment
            {
                Id = payment.Id,
                IsDeleteReminded = payment.IsDeleteReminded,
                IsFreezeReminded = payment.IsFreezeReminded,
                LastDeleteReminded = payment.LastDeleteReminded,
                LastFreeze = payment.LastFreeze,
                LastFreezeReminded = payment.LastFreezeReminded,
                LastPayment = payment.LastPayment,
                
            };

            return projectPayment;
        }
        public static Payment PaymentDto(ProjectPayment projectPayment)
        {
            if (projectPayment == null)
            {
                return new Payment();
            }

            var payment =  new Payment
            {
                Id = projectPayment.Id,
                IsDeleteReminded = projectPayment.IsDeleteReminded,
                IsFreezeReminded = projectPayment.IsFreezeReminded,
                LastDeleteReminded = projectPayment.LastDeleteReminded,
                LastFreeze = projectPayment.LastFreeze,
                LastFreezeReminded = projectPayment.LastFreezeReminded,
                LastPayment = projectPayment.LastPayment,
                Message = string.Empty,
                Severity = AppSeverity.Info,
                
            };

            return payment;
        }

        public static ProjectConfig GetProjectConfig(string config)
        {
            try
            {
                return JsonConvert.DeserializeObject<ProjectConfig>(config);
            }
            catch (Exception ex)
            {
                return new ProjectConfig();
            }
        }


        public static string GetProjectConfigJson(ProjectConfig config)
        {
            try
            {
                return JsonConvert.SerializeObject(config, Formatting.Indented);

            }
            catch (Exception ex)
            {
                return string.Empty;    
            }
        }


        public static CopyTradingProject ProjectDto(Project p)
        {
            var config = GetProjectConfig(p.ProjectConfig);
            var telegramBotResult = TelegramBot.Create(config.TelegramName, config.TelegramKey);

            TelegramBot telegramBot;
            if (!telegramBotResult.IsSuccess)
            {
                return null;
            }

            var project = new CopyTradingProject(p.Id, p.OwnerId, p.OwnerName, p.ProjectDomain, telegramBotResult.Value,
                p.ProjectName, p.ServerIP, p.ServerName, 0, p.ProxyCount, p.TraderMaxCount, p.UserMaxCount, p.TraderCount, p.UserCount,
                p.CreateDate, p.LastPing, p.State, config.Exchanges, PaymentDto(p.Payment), string.Empty, config.Tariff,
                config.DefaultLanguage, config.Languages, 0, config.AdminTelegram, config.AdminTelegramId);


            return project;
        }

    }
}
