using System;
using Android.Content;
using NLog;
using NLog.Config;
using NLog.Targets;
using Dreams.Core.Common;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Dreams.Core.Services.DreamsLog;

namespace Dreams.Droid.Services.Logger
{
    public class DreamsLogService : IDreamsLogService
    {
        private readonly Context _context;
        private readonly NLog.Logger _log;

        public DreamsLogService(Context context)
        {
            _context = context;
            _log = LogManager.GetCurrentClassLogger();
            var config = new LoggingConfiguration();

#if DEBUG
            PrepareConsoleTarget(config);
#endif

            PrepareFileTarget(config);
            LogManager.Configuration = config;
            _log = LogManager.GetLogger(DreamsResources.Common_Application_Label);
        }

        public void Log(
            string message,
            DreamsLogSeverityLevel level = DreamsLogSeverityLevel.Debug,
            Exception exception = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string fileName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            switch (level)
            {
                case DreamsLogSeverityLevel.Debug:
                    _log.Debug(message);
                    break;
                case DreamsLogSeverityLevel.Warning:
                    message = message + "|" + memberName + "|" + fileName + ":" + lineNumber;
                    _log.Warn(message);
                    break;
                case DreamsLogSeverityLevel.Error:
                    message = message + "|" + memberName + "|" + fileName + ":" + lineNumber;
                    _log.Error(exception, message);
                    break;
                default:
                    throw new InvalidEnumArgumentException("Unknown log level");
            }
        }

        private void PrepareFileTarget(LoggingConfiguration config)
        {
            var fileTarget = FileTargetFactory(_context);
            config.AddTarget("file", fileTarget);

            var rule2 = new LoggingRule("*", LogLevel.Debug, fileTarget);
            config.LoggingRules.Add(rule2);
        }

        private static void PrepareConsoleTarget(LoggingConfiguration config)
        {
            var consoleTarget = ConsoleTargetFactory();
            config.AddTarget("console", consoleTarget);

            var rule1 = new LoggingRule("*", LogLevel.Debug, consoleTarget);
            config.LoggingRules.Add(rule1);
        }

        private static FileTarget FileTargetFactory(Context context)
        {
            var fileTarget = new FileTarget();

            // The cache dir can be cleaned by the user at will
            var cacheDir = context.CacheDir.AbsolutePath;
            var appName = DreamsResources.Common_Application_Label;
            var filename = cacheDir + "/" + appName + "/logs/" + "${date:format=yyyy-MM-dd}.log";
            fileTarget.FileName = filename;
            fileTarget.Layout = "${longdate}|[${level}]|[${logger}]|${message}";
            return fileTarget;
        }

        private static ConsoleTarget ConsoleTargetFactory()
        {
            // Step 2. Create targets and add them to the configuration
            var consoleTarget = new ConsoleTarget();
            consoleTarget.Layout = @"${date:format=HH\:mm\:ss} ${logger} ${message}";
            return consoleTarget;
        }
    }
}