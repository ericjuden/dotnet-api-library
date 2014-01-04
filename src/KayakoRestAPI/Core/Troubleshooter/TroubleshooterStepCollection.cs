using System.Collections.Generic;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Troubleshooter
{
	/// <summary>
	/// Represents a list of troubleshooter steps within the helpdesk
	/// <remarks>
	/// see: http://wiki.kayako.com/display/DEV/REST+-+TroubleshooterStep#REST-TroubleshooterStep-Response
	/// </remarks>
	/// </summary>
	[XmlRoot("troubleshootersteps")]
	public class TroubleshooterStepCollection : List<TroubleshooterStep>
	{
		/// <summary>
        /// Create a list of troubleshooter steps.
        /// </summary>
		public TroubleshooterStepCollection()
        {
        }
	}
}
