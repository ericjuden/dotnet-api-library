using System.Xml.Serialization;

namespace KayakoRestApi.Core.Troubleshooter
{
	/// <summary>
	/// Represents a trouleshooter step attachment
	/// <remarks>
	/// see: http://wiki.kayako.com/display/DEV/REST+-+TroubleshooterStep#REST-TroubleshooterStep-Response
	/// </remarks>
	/// </summary>
	[XmlRoot("attachment")]
	public class TroubleshooterStepAttachment
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
