using System.Xml.Serialization;

namespace KayakoRestApi.Core.Constants
{
	public enum TicketCreationType
	{
		[XmlEnum("default")]
		Default,

		[XmlEnum("phone")]
		Phone
	}
}
