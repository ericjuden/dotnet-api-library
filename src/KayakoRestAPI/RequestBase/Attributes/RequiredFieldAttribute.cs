using System;
using System.Collections.Generic;
using System.Text;

namespace KayakoRestApi.RequestBase
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple=false)]
	internal sealed class RequiredFieldAttribute : Attribute
	{
		public RequestTypes[] RequestTypes { get; set; }

		public RequiredFieldAttribute()
		{
			RequestTypes = new RequestTypes[0];
		}

		public RequiredFieldAttribute(RequestTypes types) : base()
		{
			RequestTypes = new RequestTypes[] { types };
		}
	}
}
