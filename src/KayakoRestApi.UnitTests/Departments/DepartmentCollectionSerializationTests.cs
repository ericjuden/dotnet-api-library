using System.Collections.Generic;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.Departments;
using KayakoRestApi.UnitTests.Utilities;
using NUnit.Framework;

namespace KayakoRestApi.UnitTests.Departments
{
	[TestFixture]
	public class DepartmentCollectionSerializationTests
	{
		[Test]
		public void DepartmentCollectionDeserialization()
		{
			var expectedDepartments = new DepartmentCollection
				{
					new Department
						{
							Id = 2,
							Title = "Title",
							Type = DepartmentType.Private,
							Module = DepartmentModule.LiveChat,
							DisplayOrder = 3,
							ParentDepartmentId = 1,
							UserVisibilityCustom = false,
							UserGroups = new List<int> { 1, 2, 3 }
						}
				};

			var actualDepartments = XmlDataUtility.ReadFromFile<DepartmentCollection>("TestData/DepartmentCollection.xml");

			AssertUtility.ObjectsEqual(expectedDepartments, actualDepartments);
		}
	}
}
