using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KayakoRestApi.Core.Departments
{
	/// <summary>
	/// Definition of a list of departments
	/// <remarks>
    /// See : http://wiki.kayako.com/display/DEV/REST+-+Department
	/// </remarks>
	/// </summary>
	[XmlRoot("departments")]
	public class DepartmentCollection : List<Department>
	{
		/// <summary>
        /// Create a list of departments.
        /// </summary>
		public DepartmentCollection()
        {
        }
	}
}
