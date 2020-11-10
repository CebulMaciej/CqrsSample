using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CqrsSample.Application
{
    public static class Extensions
    {

        public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
            => serviceCollection;

        public static IApplicationBuilder UseApplication(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder;
        }
    }
}