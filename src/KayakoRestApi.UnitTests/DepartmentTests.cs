using System;
using System.Collections.Generic;
using System.Diagnostics;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.Departments;
using NUnit.Framework;

namespace KayakoRestApi.UnitTests
{
	[TestFixture(Description = "A set of tests testing Api methods around Departments")]
	public class DepartmentTests : UnitTestBase
	{
        private Department TestData
        {
            get
            {
                Department d = new Department();
                d.Title = "Test Department";
                d.Type = DepartmentType.Public;
				d.Module = DepartmentModule.Tickets;
                d.DisplayOrder = 16;
                d.ParentDepartmentId = 0;
                d.UserVisibilityCustom = true;
                d.UserGroups = new List<int>() { 1, 2, 3 };

                return d;
            }
        }

		[Test]
		public void GetAllDepartments()
		{
			DepartmentCollection departments = TestSetup.KayakoApiService.Departments.GetDepartments();

			Assert.IsNotNull(departments, "No departments were returned");
			Assert.IsNotEmpty(departments, "No departments were returned");
		}

		[Test]
		public void GetDepartment()
		{
			DepartmentCollection departments = TestSetup.KayakoApiService.Departments.GetDepartments();

			Assert.IsNotNull(departments, "No departments were returned");
			Assert.IsNotEmpty(departments, "No departments were returned");

			Department deptToGet = departments[new Random().Next(departments.Count)];

			Trace.WriteLine("GetDepartment using department id: " + deptToGet.Id);

			Department dept = TestSetup.KayakoApiService.Departments.GetDepartment(deptToGet.Id);

			CompareDepartments(dept, deptToGet);
		}

        [Test(Description="Tests creating, updating and deleting departments")]
        public void CreateUpdateDeleteDepartment()
        {
	        Department dummyData = TestData;

            Department createdDept = TestSetup.KayakoApiService.Departments.CreateDepartment(DepartmentRequest.FromResponseData(dummyData));

            Assert.IsNotNull(createdDept);
            dummyData.Id = createdDept.Id;
            CompareDepartments(dummyData, createdDept);

            dummyData.Title = "Updated Title";
			dummyData.Type = DepartmentType.Private;
            dummyData.DisplayOrder = 34;
            dummyData.UserVisibilityCustom = false;
            dummyData.UserGroups = new List<int>();

			Department updatedDept = TestSetup.KayakoApiService.Departments.UpdateDepartment(DepartmentRequest.FromResponseData(dummyData));

            Assert.IsNotNull(updatedDept);
            CompareDepartments(dummyData, updatedDept);

            bool success = TestSetup.KayakoApiService.Departments.DeleteDepartment(updatedDept.Id);

            Assert.IsTrue(success);
        }

        private void CompareDepartments(Department one, Department two)
        {
            Assert.AreEqual(one.Id, two.Id);
            Assert.AreEqual(one.Title, two.Title);
            Assert.AreEqual(one.Type, two.Type);
            Assert.AreEqual(one.Module, two.Module);
            Assert.AreEqual(one.ParentDepartmentId, two.ParentDepartmentId);
            Assert.AreEqual(one.DisplayOrder, two.DisplayOrder);
            Assert.AreEqual(one.UserVisibilityCustom, two.UserVisibilityCustom);
            Assert.AreEqual(one.UserGroups, two.UserGroups);

			AssertObjectXmlEqual<Department>(one, two);
        }
	}
}
