using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkerServiceExample.Config;

namespace WorkerServiceExample.ProcessFlow
{
    public class EmployeeTaskProcess : IEmployeeTaskProcess
    {
        private readonly EmployeeConfig _Config;
        private readonly ILogger<EmployeeTaskProcess> _logger;
        public EmployeeTaskProcess(IOptions<EmployeeConfig> config,ILogger<EmployeeTaskProcess> logger)
        {
            this._Config = config.Value;
            this._logger = logger;
        } 

        public async Task StartTheWork()
        {
            _logger.LogInformation($" Employee work started { _Config.FinishingTimeInMinutes} M^2 for {_Config.Task} Task !!! ");
            await Task.Delay(TimeSpan.FromMinutes(_Config.StartTimeInMinutes));
        }

        public async Task AssignTheWork()
        {
            _logger.LogInformation($" Employee work assign { _Config.FinishingTimeInMinutes} M^2 for {_Config.Task}  Task !!! ");
            await Task.Delay(TimeSpan.FromMinutes(_Config.WorkTimeInMinutes));
        }

        public async Task ProgressTheWork()
        {
            _logger.LogInformation($" Employee work finishing { _Config.FinishingTimeInMinutes} M^2 for {_Config.Task}  Task !!! ");
            await Task.Delay(TimeSpan.FromMinutes(_Config.FinishingTimeInMinutes));
        }

    }
}
