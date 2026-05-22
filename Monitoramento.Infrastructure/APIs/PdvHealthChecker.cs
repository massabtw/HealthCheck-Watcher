using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Monitoramento.Core.Interfaces;
using Monitoramento.Core.Models;

namespace Monitoramento.Infrastructure.APIs
{
    public class PdvHealthChecker : IHealthChecker
    {

        public string SystemName { get; } = "SistemaPDV";
        public async Task<SystemStatus> CheckHealthAsync()
        {
            await Task.Delay(50);
            return new SystemStatus
            {
                ErrorMessage = "Conexão recusada",
                IsOnline = false,
                SystemName = "SistemaPDV"
            };
        }   
    }
}
