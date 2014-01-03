using System.Collections.Generic;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Troubleshooter
{
	/// <summary>
	/// Represents a list of news categories within the helpdesk
	/// <remarks>
	/// see: http://wiki.kayako.com/display/DEV/REST+-+TroubleshooterCategory#REST-TroubleshooterCategory-Response
	/// </remarks>
	/// </summary>
	[XmlRoot("troubleshootercategories")]
	public class TroubleshooterCategoryCollection : List<TroubleshooterCategory>
	{
		/// <summary>
        /// Create a list of troubleshooter category.
        /// </summary>
		public TroubleshooterCategoryCollection()
        {
        }
	}
}
