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
        private readonly HttpClient _httpclient;

        public PdvHealthChecker(HttpClient httpClient)
        {
            _httpclient = httpClient;
        }

        public string SystemName { get; } = "SistemaPDV";

        public async Task<SystemStatus> CheckHealthAsync()
        {
            try
            {
                var resposta = await _httpclient.GetAsync("https://httpstat.us/404");
                return new SystemStatus
                {
                    IsOnline = resposta.IsSuccessStatusCode,
                    SystemName = "SistemaPDV"
                };
            }
            catch(Exception ex)
            {
                return new SystemStatus 
                {
                    ErrorMessage = "Conexão recusada",
                    SystemName = "SistemaPDV",
                    IsOnline = false
                
                };

            }

        }

    }
}
