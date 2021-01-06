#define DEBUG

using System;
namespace Rpga.Logging
{
    public class Logger
    {
        internal LogLevel _logLevel;

        /// <summary>
        /// Log destination.
        /// </summary>
        /// <remarks>
        /// Blank or "" for Event/Console output.
        /// Valid filepath to output to a text file.
        /// </remarks>
        internal string _target;

        public string Target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
            }
        }

        internal void logSelf(string message, params object[] args)
        {
            #if DEBUG
            Console.WriteLine(String.Format(message, args));
            #endif
        }

        internal bool IsFileOutput()
        {
            if (_target.Equals(System.String.Empty))
            {
                logSelf("Not outputting to a file.");
                return false;
            }
            logSelf("Outputting to file: {1}", _target);
            return true;
        }

        internal void log(
            LogLevel logLevel,
            Exception exception,
            String message,
            params object[] args)
        {
            if(!IsEnabled(logLevel))
            {
                return;
            }
            string s = String.Format(message, exception, args);
            
            Console.WriteLine(s);
        }

        public Logger(LogLevel logLevel, string target)
        {
            _logLevel = logLevel;
            _target = target;
        }

        public Logger(LogLevel logLevel)
        {
            _logLevel = logLevel;
            _target = System.String.Empty;
        }

        public Logger()
        {
            _logLevel = LogLevel.Warning;
            _target = System.String.Empty;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            if (logLevel >= _logLevel)
            {
                logSelf("Log Level {0} is enabled.", logLevel);
                return true;
            }
            else
            {
                logSelf("Log Level {0} is disabled.", logLevel);
                return false;
            }
        }

        public void Log(
            LogLevel logLevel,
            Exception exception,
            string message,
            params object[] args)
        {
            log(logLevel, exception, message, args);
        }

        public void ChangeTargetToEvent()
        {
            _target = System.String.Empty;
            logSelf("Target changed to Event (Empty String).");
        }
        public void LogTrace(Exception ex, string msg, params object[] args)
        {
            log(LogLevel.Trace, ex, msg, args);
        }

        public void LogTrace(string msg, params object[] args)
        {
            log(LogLevel.Trace, null, msg, args);
        }

        public void LogDebug(Exception ex, string msg, params object[] args)
        {
            log(LogLevel.Debug, ex, msg, args);
        }

        public void LogDebug(string msg, params object[] args)
        {
            log(LogLevel.Debug, null, msg, args);
        }

        public void LogInfo(Exception ex, string msg, params object[] args)
        {
            log(LogLevel.Info, ex, msg, args);
        }

        public void LogInfo(string msg, params object[] args)
        {
            log(LogLevel.Info, null, msg, args);
        }

        public void LogWarning(Exception ex, string msg, params object[] args)
        {
            log(LogLevel.Warning, ex, msg, args);
        }

        public void LogWarning(string msg, params object[] args)
        {
            log(LogLevel.Warning, null, msg, args);
        }

        public void LogError(Exception ex, string msg, params object[] args)
        {
            log(LogLevel.Error, ex, msg, args);
        }

        public void LogError(string msg, params object[] args)
        {
            log(LogLevel.Error, null, msg, args);
        }

        public void LogCritical(Exception ex, string msg, params object[] args)
        {
            log(LogLevel.Critical, ex, msg, args);
        }

        public void LogCritical(string msg, params object[] args)
        {
            log(LogLevel.Critical, null, msg, args);
        }
    }
}