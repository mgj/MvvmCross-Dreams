using System;
using System.Runtime.CompilerServices;

namespace Dreams.Core.Services.DreamsLog
{
    public interface IDreamsLogService
    {
        void Log(string message, DreamsLogSeverityLevel level = DreamsLogSeverityLevel.Debug, Exception exception = null, [CallerMemberName] string memberName = "", [CallerFilePath] string fileName = "", [CallerLineNumber] int lineNumber = 0);
    }
}
