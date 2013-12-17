using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Constants
{
	public enum UserOrganizationType
	{
		[XmlEnum(Name = "restricted")]
		Restricted,

		[XmlEnum(Name = "shared")]
		Shared,
	}
}
