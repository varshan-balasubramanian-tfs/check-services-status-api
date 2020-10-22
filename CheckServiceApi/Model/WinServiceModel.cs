using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckServiceApi.Model
{
    public class WinServiceModel
    {
        public string ServiceName { get; set; }
        public string ServiceDisplayName { get; set; }
        public string ServiceStatus { get; set; }
        public string ServerName { get; set; }
    }
}
