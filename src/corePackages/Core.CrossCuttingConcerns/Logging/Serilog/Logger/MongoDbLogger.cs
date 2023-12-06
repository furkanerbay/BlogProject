using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Logger;

public class MongoDbLogger : LoggerServiceBase
{
    public MongoDbLogger(IConfiguration configuration)
    {
        MongoDbConfiguration? logConfiguration = configuration
            .GetSection("SeriLogConfigurations:MongoDbConfiguration")
            .Get<MongoDbConfiguration>();

        Logger = new LoggerConfiguration().WriteTo
            .MongoDBBson(cfg =>
            {
                MongoClient client = new(logConfiguration.ConnectionString);
                IMongoDatabase? mongoDbInstance = client.GetDatabase(logConfiguration.Collection);
                cfg.SetMongoDatabase(mongoDbInstance);
            })
            .CreateLogger();
    }
}
