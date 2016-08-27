using System;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using Dreams.Core.Services.DreamsLog;

namespace Dreams.Droid
{
    public class DebugTrace : IMvxTrace
    {
        private IDreamsLogService _log;

        private IDreamsLogService Log
        {
            get
            {
                if (_log == null && Mvx.CanResolve<IDreamsLogService>())
                {
                    _log = Mvx.Resolve<IDreamsLogService>();
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
                Log?.Log($"Exception during trace of {level} {message}", DreamsLogSeverityLevel.Error, fe);
            }
        }

        private static DreamsLogSeverityLevel AllLogSeverityLevelFactory(MvxTraceLevel level)
        {
            var result = DreamsLogSeverityLevel.Debug;
            switch (level)
            {
                case MvxTraceLevel.Diagnostic:
                    result = DreamsLogSeverityLevel.Debug;
                    break;
                case MvxTraceLevel.Warning:
                    result = DreamsLogSeverityLevel.Warning;
                    break;
                case MvxTraceLevel.Error:
                    result = DreamsLogSeverityLevel.Error;
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
