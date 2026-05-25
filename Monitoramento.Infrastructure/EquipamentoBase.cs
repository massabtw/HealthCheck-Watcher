using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Monitoramento.Core.Interfaces;
using Monitoramento.Core.Models;

namespace Monitoramento.Infrastructure
{
    public class EquipamentoBase(HttpClient httpClient, string URL, string nomeDoSistema ) : IHealthChecker
    {
        public string SystemName => nomeDoSistema;

        public async Task < SystemStatus > CheckHealthAsync()
            {
                try
                {
                    var resposta = await httpClient.GetAsync(URL);
                    return new SystemStatus
                    {
                        IsOnline = resposta.IsSuccessStatusCode,
                        SystemName = nomeDoSistema
                    };
                }
                catch (Exception ex)
                {
                    return new SystemStatus
                    {
                        ErrorMessage = "Conexão recusada",
                        SystemName = nomeDoSistema,
                        IsOnline = false

                    };

                }
            }
    }
}
