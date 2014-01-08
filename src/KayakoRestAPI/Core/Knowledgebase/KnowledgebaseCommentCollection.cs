using System.Collections.Generic;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Knowledgebase
{
	/// <summary>
	/// Represents a list of troubleshooter comments within the helpdesk
	/// <remarks>
	/// see: http://wiki.kayako.com/display/DEV/REST+-+KnowledgebaseComment#REST-KnowledgebaseComment-GET%2FKnowledgebase%2FComment%2FListAll%2F%24kbarticleid%24
	/// </remarks>
	/// </summary>
	[XmlRoot("kbarticlecomments")]
	public class KnowledgebaseCommentCollection : List<KnowledgebaseComment>
	{
		/// <summary>
        /// Create a list of knowledgebase article comment.
        /// </summary>
		public KnowledgebaseCommentCollection()
        {
        }
	}
}
