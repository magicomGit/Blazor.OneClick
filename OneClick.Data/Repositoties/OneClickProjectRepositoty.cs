using Microsoft.EntityFrameworkCore;
using OneClick.Data.Data;
using OneClick.Data.Dto;
using OneClick.Domain.Domain.OneClickProjects;
using OneClick.UseCases.Intefaces.OneClickProjects;

namespace OneClick.Data.Repositoties
{
    public class OneClickProjectRepositoty : IOneClickProjectRepositoty
    {
        private ApplicationDbContext _context;
        public OneClickProjectRepositoty(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(CopyTradingProject project)
        {
            var config = new ProjectConfig
            {
                Tariff = project.Tariff,
                AdminTelegram = project.AdminTelegram,
                AdminTelegramId = project.AdminTelegramId,
                DefaultLanguage = project.DefaultLanguage,
                Exchanges = project.Exchanges,
                
            };



            Project projectEntity = new Project
            {
                Id = project.Id,
                AdminCount = 0,
                CreateDate = project.CreateDate,
                Description = string.Empty,
                EngineVersion = string.Empty,
                LastPing = project.LastPing,
                OwnerId = project.OwnerId,
                OwnerName = project.OwnerName,
                Payment = OneClickProjectDto.PaymentDto( project.Payment),
                ProjectConfig = OneClickProjectDto.GetProjectConfigJson(config),
                IsRun = 0,
                ProcessId = 0,
                ProjectDomain = project.ProjectDomain,
                ProjectName = project.ProjectName,  
                ServerIP = project.ServerIP,
                ServerName = project.ServerName,
                ProjectErrorCode = 0,
                ProjectWorkerTask = 0,
                ProxyCount = 0,
                State = project.State,
                Synchronized = project.Synchronized,
                TelegramBot = project.TelegramBot,
                TelegramKey = project.TelegramKey,
                TraderMaxCount = project.TraderMaxCount,
                TraderCount = project.TraderCount,
                UserCount = project.UserCount,
                UserMaxCount = project.UserMaxCount,
                WWWrootVersion = string.Empty,
            };



            return 0;
        }

        public  Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CopyTradingProject>> Get()
        {
            var projects = new List<CopyTradingProject>();

            var projectEntities = await _context.Projects.ToListAsync();

            if (projectEntities == null) {
                return projects;
            }

            projectEntities.ForEach(project => projects.Add(OneClickProjectDto.ProjectDto(project)));

            return projects;
        }

        public Task<CopyTradingProject> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(CopyTradingProject project)
        {
            throw new NotImplementedException();
        }
    }
}
