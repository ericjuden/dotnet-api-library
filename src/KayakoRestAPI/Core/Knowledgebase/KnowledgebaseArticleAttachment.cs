using System.Xml.Serialization;

namespace KayakoRestApi.Core.Knowledgebase
{
	public class KnowledgebaseArticleAttachment
	{
		[XmlElement("id")]
		public int Id { get; set; }

		[XmlElement("filename")]
		public string FileName { get; set; }

		[XmlElement("filesize")]
		public string FileSize { get; set; }

		[XmlElement("link")]
		public string Link { get; set; }
	}
}
