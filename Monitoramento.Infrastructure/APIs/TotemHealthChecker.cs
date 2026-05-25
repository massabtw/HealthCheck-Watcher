using Monitoramento.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Monitoramento.Core.Interfaces;


namespace Monitoramento.Infrastructure.APIs
{
    public class TotemHealthChecker(HttpClient httpClient) : EquipamentoBase(httpClient, "https://google.com", "Totem Autoatendimento")
    {
    }
}
