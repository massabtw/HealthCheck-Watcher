using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Monitoramento.Core.Interfaces;

namespace Monitoramente.Functions;

public class Function1
{
    private readonly ILogger _logger;

    private readonly IEnumerable<IHealthChecker> _healthCheckers;

    public Function1(ILoggerFactory loggerFactory, IEnumerable<IHealthChecker> healthCheckers)
    {
        _logger = loggerFactory.CreateLogger<Function1>();
        _healthCheckers = healthCheckers;
    }

    [Function("Function1")]
    public void Run([TimerTrigger("0 */2 * * * *")] TimerInfo myTimer)
    {
        _logger.LogInformation("C# Timer trigger function executed at: {executionTime}", DateTime.Now);
        
        if (myTimer.ScheduleStatus is not null)
        {
            _logger.LogInformation("Next timer schedule at: {nextSchedule}", myTimer.ScheduleStatus.Next);
        }
    }
}