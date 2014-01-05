using System.Xml.Serialization;
using KayakoRestApi.Data;

namespace KayakoRestApi.Core.Troubleshooter
{
	/// <summary>
	/// Represents a troubleshooter attachment
	/// <remarks>
	/// see: http://wiki.kayako.com/display/DEV/REST+-+TroubleshooterAttachment#REST-TroubleshooterAttachment-Response
	/// </remarks>
	/// </summary>
	[XmlType("troubleshooterattachment")]
	public class TroubleshooterAttachment
	{
		[XmlElement("id")]
		public int Id { get; set; }

		[XmlElement("troubleshooterstepid")]
		public int TroubleshooterStepId { get; set; }

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
