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
	[XmlType("customfield")]
	public class CustomField
	{
		[XmlAttribute("customfieldid")]
		public int CustomFieldId { get; set; }

		[XmlAttribute("customfieldgroupid")]
		public int CustomFieldGroupId { get; set; }

		[XmlAttribute("title")]
		public string Title { get; set; }

		[XmlAttribute("fieldtype")]
		public int FieldType { get; set; }

		[XmlAttribute("fieldname")]
		public string FieldName { get; set; }

		[XmlAttribute("defaultvalue")]
		public string DefaultValue { get; set; }

		[XmlAttribute("isrequired")]
		public bool IsRequired { get; set; }

		[XmlAttribute("usereditable")]
		public bool UserEditable { get; set; }

		[XmlAttribute("staffeditable")]
		public bool StaffEditable { get; set; }

		[XmlAttribute("regexpvalidate")]
		public string RegexValidate { get; set; }

		[XmlAttribute("displayorder")]
		public int DisplayOrder { get; set; }

		[XmlAttribute("encryptindb")]
		public bool EncryptInDatabase { get; set; }

		[XmlAttribute("description")]
		public string Description { get; set; }
	}
}
