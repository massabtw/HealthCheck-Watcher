using System;
using System.Collections.Generic;
using System.Text;

namespace Monitoramento.Core.Models
{
    public class SystemStatus
    {
        public string SystemName { get; set; } = string.Empty;
        public bool IsOnline { get; set; }
        public int ResponseMs { get; set; }
        public DateTime CheckedAt { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
