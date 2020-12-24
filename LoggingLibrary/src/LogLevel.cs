namespace Rpga.Logging
{
	/// <summary>
	/// Available Logging levels
	/// </summary>
	public enum LogLevel
	{
		/// <summary>
		/// Contain the most detailed messages.
		/// These messages may contain sensitive app data.
		/// These messages are disabled by default and should not be enabled 
		/// in production.
		/// </summary>
		Trace = 0,
		/// <summary>
		/// For debugging and development.
		/// Use with caution in production due to the high volume.
		/// </summary>
		Debug = 1,
		/// <summary>
		/// Tracks the general flow of the app.
		/// May have long-term value.
		/// </summary>
		Info = 2,
		/// <summary>
		/// For abnormal or unexpected events.
		/// Typically includes errors or conditions that don't cause the app 
		/// to fail.
		/// </summary>
		Warn = 3,
		/// <summary>
		/// For errors and exceptions that cannot be handled.
		/// These messages indicate a failure in the current operation or 
		/// request, not an app-wide failure.
		/// </summary>
		Error = 4,
		/// <summary>
		/// For failures that require immediate attention.
		/// Examples: data loss scenarios, out of disk space.
		/// </summary>
		Critical = 5,
		/// <summary>
		/// Specifies that no messages should be written.
		/// </summary>
		None = 6
	}
}