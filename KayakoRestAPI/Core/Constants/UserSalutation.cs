using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Constants
{
	public enum UserSalutation
	{
		[XmlEnum(Name = "")]
		None,

		[XmlEnum(Name = "Mr.")]
		Mr,

		[XmlEnum(Name = "Mrs.")]
		Mrs,

		[XmlEnum(Name = "Ms.")]
		Ms,

		[XmlEnum(Name = "Dr.")]
		Dr
	}
}
