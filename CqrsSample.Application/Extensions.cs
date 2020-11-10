using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CqrsSample.Application
{
    public static class Extensions
    {

        public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());

            return serviceCollection;
        }

        public static IApplicationBuilder UseApplication(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder;
        }
    }
}