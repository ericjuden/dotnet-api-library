using System.Collections.Generic;
using System.Xml.Serialization;
using KayakoRestApi.Core.CustomFields;

namespace KayakoRestApi.Core.CustomFields
{
	/// <summary>
	/// Definition of a list of departments
	/// <remarks>
	/// See : http://wiki.kayako.com/display/DEV/REST+-+CustomField
	/// </remarks>
	/// </summary>
	[XmlRoot("customfields")]
	public class CustomFieldCollection : List<CustomField>
	{
		/// <summary>
		/// Create a list of Custom Fields.
        /// </summary>
		public CustomFieldCollection()
        {
        }
	}
}
