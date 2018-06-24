using Hangfire;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireWeb.Services
{
    public interface ICheckService
    {
        void Check();
    }
    public class CheckService : ICheckService
    {
        private readonly ILogger<CheckService> _logger;
        private ITimerService _timeservice;
        public CheckService(ILoggerFactory loggerFactory,
            ITimerService timerService)
        {
            _logger = loggerFactory.CreateLogger<CheckService>();
            _timeservice = timerService;
        }

        public void Check()
        {
            _logger.LogInformation($"check service start checking, now is {DateTime.Now}");
            BackgroundJob.Schedule(() => _timeservice.Timer(), TimeSpan.FromMilliseconds(30));
            _logger.LogInformation($"check is end, now is {DateTime.Now}");
        }
    }
}
