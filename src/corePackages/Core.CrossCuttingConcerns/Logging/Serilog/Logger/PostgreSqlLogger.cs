﻿using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Core.CrossCuttingConcerns.Logging.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using NpgsqlTypes;
using Serilog.Sinks.PostgreSQL;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Logger;

public class PostgreSqlLogger : LoggerServiceBase
{
    public PostgreSqlLogger(IConfiguration configuration)
    {
        PostgreSqlConfiguration postgreConfiguration =
            configuration.GetSection("SeriLogConfigurations:PostgreConfiguration").Get<PostgreSqlConfiguration>()
            ?? throw new Exception(SerilogMessages.NullOptionsMessage);

        IDictionary<string, ColumnWriterBase> columnWriters = new Dictionary<string, ColumnWriterBase>
        {
            { "message", new RenderedMessageColumnWriter() },
            { "message_template", new MessageTemplateColumnWriter() },
            { "level", new LevelColumnWriter(renderAsText: true, NpgsqlDbType.Varchar) },
            { "raise_date", new TimestampColumnWriter() },
            { "exception", new ExceptionColumnWriter() },
            { "properties", new LogEventSerializedColumnWriter() },
            { "props_test", new PropertiesColumnWriter() },
            { "machine_name", new SinglePropertyColumnWriter(propertyName: "MachineName", PropertyWriteMethod.ToString, format: "l") }
        };

        global::Serilog.Core.Logger loggerConfiguration = new LoggerConfiguration().WriteTo
            .PostgreSQL(
                postgreConfiguration.ConnectionString,
                postgreConfiguration.TableName,
                columnWriters,
                needAutoCreateTable: postgreConfiguration.NeedAutoCreateTable
            )
            .CreateLogger();
        Logger = loggerConfiguration;
    }
}