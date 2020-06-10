using Destiny_back.Modules;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Destiny_back.Services
{
    public class CronReset: CronJobService
    {
        private readonly ILogger<CronReset> _logger;

        public CronReset(IScheduleConfig<CronReset> config, ILogger<CronReset> logger)
            : base(config.CronExpression, config.TimeZoneInfo)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CronReset starts.Time {DateTime.UtcNow}");
            return base.StartAsync(cancellationToken);
        }

        public override Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{DateTime.UtcNow} CronReset is working.");
            using (ParseData parseData = new ParseData())
            {
                parseData.Start();
            }
            _logger.LogInformation($"{DateTime.UtcNow} CronReset is ending.");
            return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CronReset is stopping.");
            return base.StopAsync(cancellationToken);
        }
    }
}
