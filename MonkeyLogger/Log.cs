using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.RollingFile;
using Serilog.Sinks.Literate;
using System.IO;

namespace MonkeyLogger
{
    public class Log
    {
        private ICorrelationProvider _correlationprovider;
        private Logger _logger;
        //private Serilog.LoggerConfiguration LoggerConfiguration;
        //private Serilog.Configuration.LoggerSinkConfiguration LoggerSinkConfig;
        public Log(ICorrelationProvider CorrelationProvider)
        {
            this._correlationprovider = CorrelationProvider;
            string path = Path.Combine(Environment.CurrentDirectory, "log-{Date}.txt");
            this._logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.RollingFile(path)
                .WriteTo.LiterateConsole()
                .CreateLogger();
        }

        public void LogInfo(string info)
        {
            this._logger.Information(info);
        }

        public void LogDebug(string info)
        {
            this._logger.Debug(info);
        }


        public void LogError(string info)
        {
            this._logger.Error(info);
        }

        public void LogWarning(string info)
        {
            this._logger.Warning(info);
        }


    }
}

