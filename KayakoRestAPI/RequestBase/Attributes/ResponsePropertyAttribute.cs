using System;
using System.Collections.Generic;
using System.Text;

namespace KayakoRestApi.RequestBase
{
	[AttributeUsage(AttributeTargets.Property)]
	internal sealed class ResponsePropertyAttribute : Attribute
	{
		public string RepsonseProperty { get; set; }

		public ResponsePropertyAttribute(string repsonseProperty)
		{
			RepsonseProperty = repsonseProperty;
		}
	}
}
