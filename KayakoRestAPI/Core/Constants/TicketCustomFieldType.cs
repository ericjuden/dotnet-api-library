using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Constants
{
	public enum TicketCustomFieldType
	{
		[XmlEnum("1")]
		Text = 1,

		[XmlEnum("2")]
		TextArea = 2,

		[XmlEnum("3")]
		Password = 3,

		[XmlEnum("4")]
		CheckBox = 4,

		[XmlEnum("5")]
		Radio = 5,

		[XmlEnum("6")]
		Select = 6,

		[XmlEnum("7")]
		MultiSelect = 7,

		[XmlEnum("8")]
		Custom = 8,

		[XmlEnum("9")]
		LinkedSelectFields = 9, 

		[XmlEnum("10")]
		Date = 10,

		[XmlEnum("11")]
		File = 11
	}
}
