using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WorkerServiceExample.ProcessFlow;

namespace WorkerServiceExample
{
    public class Worker : BackgroundService
    {
        private readonly IEmployeeTaskProcess _EmployeeTaskProcess;
        private readonly ILogger<Worker> _logger;

        public Worker(IEmployeeTaskProcess employeeTask ,ILogger<Worker> logger)
        {
            this._EmployeeTaskProcess = employeeTask;
            this._logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
                await _EmployeeTaskProcess.StartTheWork();
                await _EmployeeTaskProcess.AssignTheWork();
                await _EmployeeTaskProcess.ProgressTheWork();
            }
        }
    }
}
