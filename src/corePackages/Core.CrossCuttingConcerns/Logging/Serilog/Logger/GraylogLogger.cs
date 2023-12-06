using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Microsoft.Extensions.Configuration;
using Serilog.Sinks.Graylog;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog.Sinks.Graylog.Core.Transport;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Logger;

public class GraylogLogger : LoggerServiceBase
{
    public GraylogLogger(IConfiguration configuration)
    {
        GraylogConfiguration logConfiguration = configuration
            .GetSection("SeriLogConfigurations:GraylogConfiguration")
            .Get<GraylogConfiguration>();

        Logger = new LoggerConfiguration().WriteTo
            .Graylog(
                new GraylogSinkOptions
                {
                    HostnameOrAddress = logConfiguration.HostnameOrAddress,
                    Port = logConfiguration.Port,
                    TransportType = TransportType.Udp
                }
            )
            .CreateLogger();
    }
}
