using Destiny_back.Modules;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Destiny_back.Services
{
    public class Cron5Min: CronJobService
    {
        private readonly ILogger<Cron5Min> _logger;
        //private readonly IScheduleConfig<CronReset> con;


        public Cron5Min(IScheduleConfig<CronReset> config, ILogger<Cron5Min> logger)
            : base(config.CronExpression, config.TimeZoneInfo)
        {
            _logger = logger;
            //con = config;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Cron5Min starts.Time {DateTime.UtcNow}");
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{DateTime.UtcNow} Cron5Min is working 5 min.");
            using (ParseData parseData = new ParseData())
            {
                parseData.Start();
            }
            _logger.LogInformation($"{DateTime.UtcNow} Cron5Min is ending 5 min.");
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Cron5Min is stopping 5 min.");
            return base.StopAsync(cancellationToken);
        }
    }
}
