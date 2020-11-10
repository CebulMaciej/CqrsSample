using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CqrsSample.Application;
using CqrsSample.Infrastructure;
using MediatR;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CqrsSample.Api
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateWebHostBuilder(args).Build().RunAsync();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                    {
                        services.AddControllers();
                        services.AddMvc();
                        services.AddMediatR(Assembly.GetExecutingAssembly());
                        
                        services
                            .AddApplication()
                            .AddInfrastructure();
                    }
                )
                .Configure(app =>
                    {
                        app.UseRouting();
                        app
                            .UseApplication()
                            .UseInfrastructure();
                        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
                    }
                );

    }
}