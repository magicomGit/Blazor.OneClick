using OneClick.Domain.Domain.OneClickProjects;
using OneClick.UseCases.Intefaces.OneClickProjects;

namespace OneClick.Services.OneClickProjects
{
    


    public class OneClickProjectRepositoty : IOneClickProjectRepositoty
    {
        

        public Task<int> Create(CopyTradingProject project)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CopyTradingProject>> Get()
        {
            throw new NotImplementedException();
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
