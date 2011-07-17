using System;

namespace KayakoRestApi.Utilities
{
    /// <summary>
    /// Utility to convert between DateTime and Unix Time
    /// </summary>
	public static class UnixTimeUtility
	{
        /// <summary>
        /// Converts a DateTime object to Unix Time
        /// </summary>
		public static long ToUnixTime(DateTime dateTime)
		{
			DateTime unixRef = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			TimeSpan diff = dateTime - unixRef;

			return (long)Math.Floor(diff.TotalSeconds);
		}

        /// <summary>
        /// Converts a Unix Time to a DateTime object
        /// </summary>
		public static DateTime FromUnixTime(long unixTime)
		{
			DateTime unixRef = new DateTime(1970, 1, 1, 0, 0, 0);

			return unixRef.AddSeconds(unixTime);
		}
	}
}
