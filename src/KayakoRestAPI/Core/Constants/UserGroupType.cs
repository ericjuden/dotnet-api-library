using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Constants
{
	public enum UserGroupType
	{
		[XmlEnum(Name = "guest")]
		Guest,

		[XmlEnum(Name = "registered")]
		Registered,
	}
}
