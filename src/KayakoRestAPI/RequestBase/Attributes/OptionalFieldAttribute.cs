using System;
using System.Collections.Generic;
using System.Text;

namespace KayakoRestApi.RequestBase
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    internal sealed class OptionalFieldAttribute : Attribute
	{
		public OptionalFieldAttribute()
			: base()
		{
		}
	}
}
