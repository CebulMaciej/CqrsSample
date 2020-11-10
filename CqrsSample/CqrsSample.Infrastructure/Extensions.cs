using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
namespace CqrsSample.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
            => serviceCollection;
        
        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder;
        }
    }
}