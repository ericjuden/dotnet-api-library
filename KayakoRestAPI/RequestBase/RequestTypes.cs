using System;
using System.Collections.Generic;
using System.Text;

namespace KayakoRestApi.RequestBase
{
    /// <summary>
    /// Enum representing the different Api request types
    /// </summary>
	[Flags]
	public enum RequestTypes
	{
        /// <summary>
        /// Create (POST) Api method requests
        /// </summary>
		Create,

        /// <summary>
        /// Update (PUT) Api method requests
        /// </summary>
		Update
	}
}
