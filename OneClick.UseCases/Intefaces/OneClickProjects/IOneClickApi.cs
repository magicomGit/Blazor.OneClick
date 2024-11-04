using OneClick.Domain.Enums.Project;

namespace OneClick.UseCases.Intefaces.OneClickProjects
{
    public interface IOneClickApi<TResponse>
    {
        Task<TResponse> GetProjectsAsync(string serverIp);
        Task<TResponse> GetProjectAsync(string serverIp, string projectName);
        Task<TResponse> ChangeState(string serverIp, string projectName, ProjectState newState);
    }
}
