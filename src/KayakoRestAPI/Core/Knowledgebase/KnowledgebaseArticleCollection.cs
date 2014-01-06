using System.Collections.Generic;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Knowledgebase
{
	/// <summary>
	/// Represents a list of knowledgebase articles within the helpdesk
	/// <remarks>
	/// see: http://wiki.kayako.com/display/DEV/REST+-+KnowledgebaseArticle#REST-KnowledgebaseArticle-Response
	/// </remarks>
	/// </summary>
	[XmlRoot("kbarticles")]
	public class KnowledgebaseArticleCollection : List<KnowledgebaseArticle>
	{
		/// <summary>
		/// Create a list of knowledgebase articles.
        /// </summary>
		public KnowledgebaseArticleCollection()
        {
        }
	}
}
