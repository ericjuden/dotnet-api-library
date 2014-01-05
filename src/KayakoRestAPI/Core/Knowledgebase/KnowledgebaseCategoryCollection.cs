using System.Collections.Generic;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Knowledgebase
{
	/// <summary>
	/// Represents a list of troubleshooter categories within the helpdesk
	/// <remarks>
	/// see: http://wiki.kayako.com/display/DEV/REST+-+KnowledgebaseCategory#REST-KnowledgebaseCategory-Response
	/// </remarks>
	/// </summary>
	[XmlRoot("kbcategories")]
	public class KnowledgebaseCategoryCollection : List<KnowledgebaseCategory>
	{
		/// <summary>
		/// Create a list of knowledgebase category.
        /// </summary>
		public KnowledgebaseCategoryCollection()
        {
        }
	}
}
