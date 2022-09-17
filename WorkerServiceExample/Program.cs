using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkerServiceExample.Config;
using WorkerServiceExample.ProcessFlow;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;

namespace WorkerServiceExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.AddEventLog();
                })
                //Essential to run this as a window service
                .UseWindowsService()
                .ConfigureServices(ConfigureServices);
                

        public static void ConfigureServices(HostBuilderContext context, IServiceCollection services )
        {
            //Getting the value from the Json config.
            services.Configure<EmployeeConfig>(context.Configuration.GetSection("WaitingDuration"));
            services.AddLogging();
            //Dependency Injection
            services.AddTransient<IEmployeeTaskProcess, EmployeeTaskProcess>();
            //Worker Service to assign
            services.AddHostedService<Worker>();
        }
    }
}
