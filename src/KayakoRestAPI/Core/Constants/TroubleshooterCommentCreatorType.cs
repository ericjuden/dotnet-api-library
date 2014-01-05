using System.Xml.Serialization;

namespace KayakoRestApi.Core.Constants
{
	public enum TroubleshooterCommentCreatorType
	{
		[XmlEnum(Name = "1")]
		Staff,

		[XmlEnum(Name = "2")]
		User
	}
}
