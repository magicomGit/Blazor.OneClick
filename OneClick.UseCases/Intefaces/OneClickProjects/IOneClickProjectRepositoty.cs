using OneClick.Domain.Domain.OneClickProjects;

namespace OneClick.UseCases.Intefaces.OneClickProjects
{
    public interface  IOneClickProjectRepositoty
    {
        Task<List<CopyTradingProject>> Get();

        Task<CopyTradingProject> GetById(long id);

        Task<int> Create(CopyTradingProject project);

        Task<int> Update(CopyTradingProject project);

        Task<int> Delete(int id);
    }
}
