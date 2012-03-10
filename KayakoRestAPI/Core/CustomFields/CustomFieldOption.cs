using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.CustomFields
{
	/// <summary>
	/// Represents a custom field
	/// </summary>
	/// <remarks>
	/// http://wiki.kayako.com/display/DEV/REST+-+CustomField
	/// </remarks>
	[XmlType("option")]
	public class CustomFieldOption
	{
		[XmlAttribute("customfieldoptionid")]
		public int CustomFieldOptionId { get; set; }

		[XmlAttribute("customfieldid")]
		public int CustomFieldId { get; set; }

		[XmlAttribute("optionvalue")]
		public string OptionValue { get; set; }

		[XmlAttribute("displayorder")]
		public int DisplayOrder { get; set; }

		[XmlAttribute("isselected")]
		public bool IsSelected { get; set; }

		[XmlAttribute("parentcustomfieldoptionid")]
		public int ParentCustomFieldOptionId { get; set; }
	}
}
