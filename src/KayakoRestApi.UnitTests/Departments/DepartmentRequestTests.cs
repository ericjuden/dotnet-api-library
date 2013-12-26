using System.Collections.Generic;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.Departments;
using KayakoRestApi.RequestBase;
using KayakoRestApi.UnitTests.Utilities;
using NUnit.Framework;

namespace KayakoRestApi.UnitTests.Departments
{
	[TestFixture]
	public class DepartmentRequestTests
	{
		[Test]
		public void IsValidTest()
		{
			var departmentRequest = new DepartmentRequest
				{
					DisplayOrder = 2,
					Module = DepartmentModule.LiveChat,
					ParentDepartmentId = 2,
					Title = "Title",
					Type = DepartmentType.Private,
					UserGroups = new List<int>(),
					UserVisibilityCustom = false
				};

			Assert.IsTrue(departmentRequest.IsValid(RequestTypes.Create));
			Assert.IsTrue(departmentRequest.IsValid(RequestTypes.Update));
			Assert.DoesNotThrow(() => departmentRequest.EnsureValidData(RequestTypes.Create));
			Assert.DoesNotThrow(() => departmentRequest.EnsureValidData(RequestTypes.Update));
		}

		[Test]
		public void EnsureValidDataTest()
		{
			var departmentRequest = new DepartmentRequest
			{
				DisplayOrder = 2,
				Module = DepartmentModule.LiveChat,
				ParentDepartmentId = 2,
				Title = "Title",
				Type = DepartmentType.Private,
				UserGroups = new List<int>(),
				UserVisibilityCustom = false
			};

			Assert.DoesNotThrow(() => departmentRequest.EnsureValidData(RequestTypes.Create));
			Assert.DoesNotThrow(() => departmentRequest.EnsureValidData(RequestTypes.Update));
		}

		[Test]
		public void FromResponseDataTest()
		{
			var departmentRequest = new DepartmentRequest
			{
				Id = 2,
				DisplayOrder = 2,
				Module = DepartmentModule.LiveChat,
				ParentDepartmentId = 2,
				Title = "Title",
				Type = DepartmentType.Private,
				UserGroups = new List<int>(),
				UserVisibilityCustom = false
			};

			var department = new Department
				{
					Id = 2,
					DisplayOrder = 2,
					Module = DepartmentModule.LiveChat,
					ParentDepartmentId = 2,
					Title = "Title",
					Type = DepartmentType.Private,
					UserGroups = new List<int>(),
					UserVisibilityCustom = false
				};

			var departmentRequestResult = DepartmentRequest.FromResponseData(department);

			AssertUtility.ObjectsEqual(departmentRequest, departmentRequestResult);
		}

		[Test]
		public void ToResponseDataTest()
		{
			var departmentRequest = new DepartmentRequest
			{
				Id = 2,
				DisplayOrder = 2,
				Module = DepartmentModule.LiveChat,
				ParentDepartmentId = 2,
				Title = "Title",
				Type = DepartmentType.Private,
				UserGroups = new List<int>(),
				UserVisibilityCustom = false
			};

			var department = new Department
			{
				Id = 2,
				DisplayOrder = 2,
				Module = DepartmentModule.LiveChat,
				ParentDepartmentId = 2,
				Title = "Title",
				Type = DepartmentType.Private,
				UserGroups = new List<int>(),
				UserVisibilityCustom = false
			};

			var departmentResult = DepartmentRequest.ToResponseData(departmentRequest);

			AssertUtility.ObjectsEqual(department, departmentResult);
		}
	}
}
