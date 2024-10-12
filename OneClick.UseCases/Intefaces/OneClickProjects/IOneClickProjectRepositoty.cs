using OneClick.Domain.Domain.OneClickProjects;

namespace OneClick.UseCases.Intefaces.OneClickProjects
{
    public interface  IOneClickProjectRepositoty
    {
        Task<List<CopyTradingProject>> Get();
        Task<List<CopyTradingProject>> GetByOwnerId(Guid ownerId);

        Task<string> GetProjectLogo(int projectId);

        Task<string> GetProjectLogoMini(int projectId);

        Task<CopyTradingProject?> GetById(int id,  bool logoRequired =false, bool miniAvatar = true);

        Task<int> Create(CopyTradingProject project);

        Task<int> Update(CopyTradingProject project);

        Task<int> Delete(int id);
    }
}
