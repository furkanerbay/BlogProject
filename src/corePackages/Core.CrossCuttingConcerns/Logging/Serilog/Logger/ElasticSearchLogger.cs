using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Microsoft.Extensions.Configuration;
using Serilog.Formatting.Elasticsearch;
using Serilog.Sinks.Elasticsearch;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Logger;

public class ElasticSearchLogger : LoggerServiceBase
{
    public ElasticSearchLogger(IConfiguration configuration)
    {
        ElasticSearchConfiguration? logConfiguration = configuration
            .GetSection("SeriLogConfigurations:ElasticSearchConfiguration")
            .Get<ElasticSearchConfiguration>();

        Logger = new LoggerConfiguration().WriteTo
            .Elasticsearch(
                new ElasticsearchSinkOptions(new Uri(logConfiguration.ConnectionString))
                {
                    AutoRegisterTemplate = true,
                    AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
                    CustomFormatter = new ExceptionAsObjectJsonFormatter(renderMessage: true)
                }
            )
            .CreateLogger();
    }
}
