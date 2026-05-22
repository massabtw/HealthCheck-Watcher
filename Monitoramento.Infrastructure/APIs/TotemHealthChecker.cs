using Monitoramento.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Monitoramento.Core.Interfaces;


namespace Monitoramento.Infrastructure.APIs
{
    public class TotemHealthChecker : IHealthChecker
    {
        public string SystemName { get; } = "Totem Autoatendimento";

        public async Task<SystemStatus>CheckHealthAsync()
        {
            await Task.Delay(50);
            return new SystemStatus
            {
                IsOnline = true,
                SystemName = "Totem Autoatendimento"
            };

        }
    }
}
