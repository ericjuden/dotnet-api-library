using System.Collections.Generic;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Troubleshooter
{
	/// <summary>
	/// Represents a list of troubleshooter categories within the helpdesk
	/// <remarks>
	/// see: http://wiki.kayako.com/display/DEV/REST+-+TroubleshooterAttachment#REST-TroubleshooterAttachment-Response
	/// </remarks>
	/// </summary>
	[XmlRoot("troubleshooterattachments")]
	public class TroubleshooterAttachmentCollection : List<TroubleshooterAttachment>
	{
		/// <summary>
        /// Create a list of troubleshooter attachments.
        /// </summary>
		public TroubleshooterAttachmentCollection()
        {
        }
	}
}
