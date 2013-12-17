using System;
using System.Collections.Generic;
using System.Text;
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
