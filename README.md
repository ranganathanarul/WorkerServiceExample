# WorkerServiceExample
Worker service example with .NET Core

Installation with worker service -
![image](https://user-images.githubusercontent.com/85032095/190879232-eeccd350-d1b3-4a79-b641-7dbbb4938548.png)


Process Diagram -

![image](https://user-images.githubusercontent.com/85032095/190879336-dc9c2a16-b7ef-47a3-975b-db6ecc9161c3.png)

Difference between Windows service vs Worker service -

![image](https://user-images.githubusercontent.com/85032095/190879372-7de2d8c8-efa0-4a09-8452-c0ae2cdd237a.png)

Worker class code Example

![image](https://user-images.githubusercontent.com/85032095/190879426-55f0ac11-7d90-4bdb-a7e1-a992aad02c1a.png)

startup class code.

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

