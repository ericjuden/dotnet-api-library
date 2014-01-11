using System.Xml.Serialization;
using KayakoRestApi.Data;

namespace KayakoRestApi.Core.Knowledgebase
{
	/// <summary>
	/// Represents a knowledgebase attachment
	/// <remarks>
	/// see: http://wiki.kayako.com/display/DEV/REST+-+KnowledgebaseAttachment#REST-KnowledgebaseAttachment-Response
	/// </remarks>
	/// </summary>
	[XmlType("kbattachment")]
	public class KnowledgebaseAttachment
	{
		[XmlElement("id")]
		public int Id { get; set; }

		[XmlElement("kbarticleid")]
		public int KnowledgebaseArticleId { get; set; }

		[XmlElement("filename")]
		public string FileName { get; set; }

		[XmlElement("filesize")]
		public long FileSize { get; set; }

		[XmlElement("filetype")]
		public string FileType { get; set; }

		[XmlElement("dateline")]
		public UnixDateTime DateLine { get; set; }

		/// <summary>
		/// The BASE64 encoded attachment contents
		/// </summary>
		[XmlElement("contents")]
		public string Contents { get; set; }
	}
}
