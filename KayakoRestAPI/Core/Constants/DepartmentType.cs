using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Constants
{
	public enum DepartmentType
	{
		[XmlEnum(Name = "public")]
		Public,

		[XmlEnum(Name = "private")]
		Private
	}
}
