using Microsoft.EntityFrameworkCore;
using OneClick.Data.Constants;
using OneClick.Data.Data;
using OneClick.Data.Dto;
using OneClick.Data.Enums;
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
                Payment = OneClickProjectDto.PaymentDto(project.Payment),
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
                TelegramBot = project.TelegramBot.TelegramBotName,
                TelegramKey = project.TelegramBot.TelegramBotKey,
                TraderMaxCount = project.TraderMaxCount,
                TraderCount = project.TraderCount,
                UserCount = project.UserCount,
                UserMaxCount = project.UserMaxCount,
                WWWrootVersion = string.Empty,
            };



            return 0;
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CopyTradingProject>> Get()
        {
            var projects = new List<CopyTradingProject>();

            var projectEntities = await _context.Projects.ToListAsync();

            if (projectEntities == null)
            {
                return projects;
            }

            projectEntities.ForEach(project => projects.Add(OneClickProjectDto.ProjectDto(project)));

            return projects;
        }

        public async Task<CopyTradingProject?> GetById(int id, bool logoRequired = false, bool miniAvatar = true)
        {            
            var projectEntity = await _context.Projects.Where(x => x.Id == id).AsNoTracking().Include(x => x.Payment).FirstOrDefaultAsync(); ;

            if (projectEntity != null)
            {
                var project = OneClickProjectDto.ProjectDto(projectEntity);
                if (project != null && logoRequired)
                {
                    var logo = await GetLogoAsync(id, miniAvatar);
                    project.Logo = logo;
                }

                return project;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<CopyTradingProject>> GetByOwnerId(Guid ownerId)
        {
            var projects = new List<CopyTradingProject>();

            var projectEntities = await _context.Projects.Where(x => x.OwnerId == ownerId).ToListAsync();

            if (projectEntities == null)
            {
                return projects;
            }

            projectEntities.ForEach(project => projects.Add(OneClickProjectDto.ProjectDto(project)));

            return projects;
        }


        public async Task<string> GetProjectLogo(int projectId)
        {
            var avatarResult = await _context.ProjectsData.Where(x => x.ProjectId == projectId && x.Name == ProjectDataNames.Avatar.ToString())
                .AsNoTracking().FirstOrDefaultAsync();

            if (avatarResult == null || string.IsNullOrEmpty(avatarResult.Value))
            {
                return SystemLogo.Content;
            }
            else
            {
                return avatarResult.Value;
            }
        }

        public async Task<string> GetProjectLogoMini(int projectId)
        {
            var avatarResult = await _context.ProjectsData.Where(x => x.ProjectId == projectId && x.Name == ProjectDataNames.AvatarMini.ToString())
                .AsNoTracking().FirstOrDefaultAsync();

            if (avatarResult == null || string.IsNullOrEmpty(avatarResult.Value))
            {
                return SystemLogo.ContentMini;
            }
            else
            {
                return avatarResult.Value;
            }
        }

        public Task<int> Update(CopyTradingProject project)
        {
            throw new NotImplementedException();
        }


        //============================ private methods =====================
        public async Task<string> GetLogoAsync(int projectId, bool miniAvatar = false)
        {
            var dataName = ProjectDataNames.Avatar.ToString();
            if (miniAvatar)
            {
                dataName = ProjectDataNames.AvatarMini.ToString();
            }



            var avatar = string.Empty;
            var avatarResult = await _context.ProjectsData.Where(x => x.ProjectId == projectId && x.Name == dataName)
                .AsNoTracking().FirstOrDefaultAsync();

            if (dataName == ProjectDataNames.AvatarMini.ToString())
            {
                if (avatarResult == null || string.IsNullOrEmpty(avatarResult.Value))//если мини лого не загрузился пробуем загрузить большой
                {
                    avatarResult = await _context.ProjectsData.Where(x => x.ProjectId == projectId && x.Name == ProjectDataNames.Avatar.ToString())
                        .AsNoTracking().FirstOrDefaultAsync();
                    if (avatarResult != null && !string.IsNullOrEmpty(avatarResult.Value))
                    {
                        avatar = avatarResult.Value;
                    }
                    else
                    {
                        avatar = SystemLogo.ContentMini;
                    }
                }
                else
                {
                    avatar = avatarResult.Value;
                }
            }
            else
            {
                if (avatarResult != null && !string.IsNullOrEmpty(avatarResult.Value))
                {
                    avatar = avatarResult.Value;
                }
                else
                {
                    avatar = SystemLogo.ContentMini;
                }
            }



            return avatar;
        }
    }
}
