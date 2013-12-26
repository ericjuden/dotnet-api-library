using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Configuration;
using KayakoRestApi.Core.Departments;
using KayakoRestApi;
using System.Diagnostics;
using KayakoRestApi.Core.Staff;

namespace KayakoRestApi.IntegrationTests
{
	[TestFixture(Description = "A set of tests testing Api methods around Staff Groups")]
	public class StaffGroupTests : UnitTestBase
	{
        private StaffGroup TestData
        {
            get
            {
				StaffGroup staffGroup = new StaffGroup();
				staffGroup.IsAdmin = false;
				staffGroup.Title = "Staff Group Test";

				return staffGroup;
            }
        }

		[Test]
		public void GetAllStaffGroups()
		{
			StaffGroupCollection staffGroups = TestSetup.KayakoApiService.Staff.GetStaffGroups();

            Assert.IsNotNull(staffGroups, "No staff groups were returned");
			Assert.IsNotEmpty(staffGroups, "No staff groups were returned");
		}

		[Test]
		public void GetStaffGroup()
		{
			StaffGroupCollection staffGroups = TestSetup.KayakoApiService.Staff.GetStaffGroups();

			Assert.IsNotNull(staffGroups, "No staff groups were returned");
			Assert.IsNotEmpty(staffGroups, "No staff groups were returned");

			StaffGroup staffGroupToGet = staffGroups[new Random().Next(staffGroups.Count)];

            Trace.WriteLine("GetStaffGroup using staff group id: " + staffGroupToGet.Id);

			StaffGroup staffGroup = TestSetup.KayakoApiService.Staff.GetStaffGroup(staffGroupToGet.Id);

			CompareStaffGroups(staffGroup, staffGroupToGet);
		}

        [Test(Description="Tests creating, updating and deleting staff groups")]
        public void CreateUpdateDeleteStaffGroup()
        {
            StaffGroup dummyStaffGroup = TestData;

            StaffGroup createdStaffGroup = TestSetup.KayakoApiService.Staff.CreateStaffGroup(StaffGroupRequest.FromResponseData(dummyStaffGroup));

            Assert.IsNotNull(createdStaffGroup);
			dummyStaffGroup.Id = createdStaffGroup.Id;
            CompareStaffGroups(dummyStaffGroup, createdStaffGroup);

			dummyStaffGroup.IsAdmin = true;
			dummyStaffGroup.Title = "UPDATED: Staff Group Test";

            StaffGroup updatedStaffGroup = TestSetup.KayakoApiService.Staff.UpdateStaffGroup(StaffGroupRequest.FromResponseData(dummyStaffGroup));

            Assert.IsNotNull(updatedStaffGroup);
			CompareStaffGroups(dummyStaffGroup, updatedStaffGroup);

            bool success = TestSetup.KayakoApiService.Staff.DeleteStaffGroup(updatedStaffGroup.Id);

            Assert.IsTrue(success);
        }

        private void CompareStaffGroups(StaffGroup one, StaffGroup two)
        {
            Assert.AreEqual(one.Id, two.Id);
            Assert.AreEqual(one.IsAdmin, two.IsAdmin);
            Assert.AreEqual(one.Title, two.Title);

			AssertObjectXmlEqual<StaffGroup>(one, two);
        }
	}
}
