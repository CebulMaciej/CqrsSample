using System.Reflection;
using CqrsSample.Application.Services;
using CqrsSample.Infrastructure.Services;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
namespace CqrsSample.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
            serviceCollection.AddSingleton<IExampleRepository, ExampleRepository>();
            return serviceCollection;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder;
        }
    }
}