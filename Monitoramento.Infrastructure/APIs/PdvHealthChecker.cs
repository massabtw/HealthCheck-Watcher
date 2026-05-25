using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Monitoramento.Core.Interfaces;
using Monitoramento.Core.Models;

namespace Monitoramento.Infrastructure.APIs
{
    public class PdvHealthChecker(HttpClient httpClient) : EquipamentoBase(httpClient, "https://httpstat.us/404", "SistemPDV")
    {

    }
}
