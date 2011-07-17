using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Xml.Serialization;

namespace KayakoRestApi.Data
{
	internal static class EnumUtility
	{
        internal static string ToApiString(object enumValue)
		{
			FieldInfo fi = enumValue.GetType().GetField(enumValue.ToString());
			
			XmlEnumAttribute[] attributes = (XmlEnumAttribute[])fi.GetCustomAttributes(typeof(XmlEnumAttribute), false);

			return (attributes.Length > 0) ? attributes[0].Name : enumValue.ToString();
		}
	}
}
