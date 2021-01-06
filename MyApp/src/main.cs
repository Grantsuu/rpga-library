using System;
using Rpga.Logging;
using Rpga.Combat;

class main
{
	static void Main(string[] args)
	{
		Console.WriteLine("Hello World!");
		Logger logger = new Logger(LogLevel.Trace, System.String.Empty);
		
		int i = 10;
		int j = 25;

		ArgumentException ex = new ArgumentException();

		logger.Log(
			LogLevel.Critical,
			ex,
			"Value i: {0}",
			i
		);

        logger.LogTrace("Trace without an exception. What does the null say?");
	}
}