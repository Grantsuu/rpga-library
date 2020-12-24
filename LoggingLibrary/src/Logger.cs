#define DEBUG

using System;
namespace Rpga.Logging
{
	public class Logger
	{
		private LogLevel _logLevel;

		private IFormatProvider _formatProvider;

		private void logSelf(string message, params object[] args)
		{
			#if DEBUG
			Console.WriteLine(String.Format(message, args));
			#endif
		}

		private string applyFormat(string format, params object[] args)
		{
			if(_formatProvider == null)
			{
				return String.Format(format, args);
			}
			return String.Format(_formatProvider, format, args);
		}

		private void log(
			LogLevel logLevel,
			Exception exception,
			String message,
			params object[] args)
		{
			if(!IsEnabled(logLevel))
			{
				return;
			}
			string s = applyFormat("{0}\n{1}", String.Format(message, args), exception.ToString());
			Console.WriteLine(s);
		}

		public Logger(LogLevel logLevel)
		{
			_logLevel = logLevel;
			_formatProvider = null;
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
	}
}