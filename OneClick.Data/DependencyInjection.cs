using Microsoft.Extensions.DependencyInjection;

namespace OneClick.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddData(this IServiceCollection services)
        {
            return services;
        }
    }
}
