using Monitoramento.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Monitoramento.Core.Interfaces;


namespace Monitoramento.Infrastructure.APIs
{
    public class TotemHealthChecker : IHealthChecker
    {
        private readonly HttpClient _httpClient;

        public TotemHealthChecker(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public string SystemName { get; } = "Totem Autoatendimento";

        public async Task<SystemStatus>CheckHealthAsync()
        {
            try
            {
                var resposta = await _httpClient.GetAsync("https://www.google.com");
                return new SystemStatus
                {
                    IsOnline = resposta.IsSuccessStatusCode,
                    SystemName = "Totem Autoatendimento"
                };
            }
            catch (Exception ex)
            {
                return new SystemStatus 
                {
                    ErrorMessage = "Conexão recusada",
                    IsOnline = false,
                    SystemName = "Totem Autoatendimento"
                
                };

            }

        }
    }
}
