using System;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using artm.MvxPlugins.Logger.Services;

namespace Dreams.Droid
{
    public class DebugTrace : IMvxTrace
    {
        private ILoggerService _log;

        private ILoggerService Log
        {
            get
            {
                if (_log == null && Mvx.CanResolve<ILoggerService>())
                {
                    _log = Mvx.Resolve<ILoggerService>();
                }

                return _log;
            }

            set
            {
                _log = value;
            }
        }

        public DebugTrace()
        {
        }

        public void Trace(MvxTraceLevel level, string tag, Func<string> message)
        {
            var msg = message.Invoke();
            Log?.Log(msg, AllLogSeverityLevelFactory(level));
        }

        public void Trace(MvxTraceLevel level, string tag, string message)
        {
            Log.Log(message, AllLogSeverityLevelFactory(level));
        }

        public void Trace(MvxTraceLevel level, string tag, string message, params object[] args)
        {
            try
            {
                Log?.Log(message, AllLogSeverityLevelFactory(level));
            }
            catch (FormatException fe)
            {
                Log?.Log($"Exception during trace of {level} {message}", LoggerServiceSeverityLevel.Error, fe);
            }
        }

        private static LoggerServiceSeverityLevel AllLogSeverityLevelFactory(MvxTraceLevel level)
        {
            var result = LoggerServiceSeverityLevel.Debug;
            switch (level)
            {
                case MvxTraceLevel.Diagnostic:
                    result = LoggerServiceSeverityLevel.Debug;
                    break;
                case MvxTraceLevel.Warning:
                    result = LoggerServiceSeverityLevel.Warning;
                    break;
                case MvxTraceLevel.Error:
                    result = LoggerServiceSeverityLevel.Error;
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
