using Monitoramento.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monitoramento.Core.Interfaces
{
    public interface IHealthChecker
    {
        string SystemName { get; }
        Task<SystemStatus> CheckHealthAsync();
    }
}
