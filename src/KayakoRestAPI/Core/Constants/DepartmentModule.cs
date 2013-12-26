using System.Xml.Serialization;

namespace KayakoRestApi.Core.Constants
{
	public enum DepartmentModule
	{
		[XmlEnum(Name = "tickets")]
		Tickets,

		[XmlEnum(Name = "livechat")]
		LiveChat
	}
}
