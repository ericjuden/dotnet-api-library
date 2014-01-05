using System.Collections.Generic;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Troubleshooter
{
	/// <summary>
	/// Represents a list of troubleshooter comments within the helpdesk
	/// <remarks>
	/// see: http://wiki.kayako.com/display/DEV/REST+-+TroubleshooterComment#REST-TroubleshooterComment-Response
	/// </remarks>
	/// </summary>
	[XmlRoot("troubleshooterstepcomments")]
	public class TroubleshooterCommentCollection : List<TroubleshooterComment>
	{
		/// <summary>
        /// Create a list of troubleshooter comment.
        /// </summary>
		public TroubleshooterCommentCollection()
        {
        }
	}
}
