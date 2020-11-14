using System.Reflection;
using CqrsSample.Application.Services;
using CqrsSample.Infrastructure.Mongo.Abstract;
using CqrsSample.Infrastructure.Mongo.Concrete;
using CqrsSample.Infrastructure.Options;
using CqrsSample.Infrastructure.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace CqrsSample.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
            serviceCollection.AddTransient<IEventProcessor,EventProcessor>();

            serviceCollection.AddTransient<IMongoClientProvider, MongoClientProvider>();
            serviceCollection.AddTransient<IMongoDatabaseProvider, MongoDatabaseProvider>();
            serviceCollection.AddTransient<IMongoCollectionProvider,MongoCollectionProvider>();
            
            serviceCollection.AddSingleton<IExampleRepository, MongoExampleRepository>();

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            IConfiguration configuration = serviceProvider.GetService<IConfiguration>();

            MongoOptions mongoOptions = configuration.GetSection("Mongo").Get<MongoOptions>();

            serviceCollection.AddSingleton(mongoOptions);
            
            return serviceCollection;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder;
        }
    }
}