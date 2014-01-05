using System.Xml.Serialization;

namespace KayakoRestApi.Core.Constants
{
	public enum TroubleshooterCommentStatus
	{
		[XmlEnum(Name = "1")]
		PendingForApproval,

		[XmlEnum(Name = "2")]
		Approved,

		[XmlEnum(Name = "3")]
		MarkedAsSpam
	}
}
