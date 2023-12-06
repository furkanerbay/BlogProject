using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;

public class GraylogConfiguration
{
    public string? HostnameOrAddress { get; set; }
    public int Port { get; set; }
}
