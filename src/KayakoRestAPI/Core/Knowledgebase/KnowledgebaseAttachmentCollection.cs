using System.Collections.Generic;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Knowledgebase
{
	/// <summary>
	/// Represents a list of knowledgebase attachments within the helpdesk
	/// <remarks>
	/// see: http://wiki.kayako.com/display/DEV/REST+-+KnowledgebaseAttachment#REST-KnowledgebaseAttachment-Response
	/// </remarks>
	/// </summary>
	[XmlRoot("kbattachments")]
	public class KnowledgebaseAttachmentCollection : List<KnowledgebaseAttachment>
	{
		/// <summary>
		/// Create a list of knowledgebase attachments.
        /// </summary>
		public KnowledgebaseAttachmentCollection()
        {
        }
	}
}
