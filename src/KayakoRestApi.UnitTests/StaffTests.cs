using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Configuration;
using KayakoRestApi;
using System.Diagnostics;
using KayakoRestApi.Core.Staff;

namespace KayakoRestApi.UnitTests
{
	[TestFixture(Description = "A set of tests testing Api methods around Staff Users")]
	public class StaffTests : UnitTestBase
	{
        private StaffUser TestData
        {
            get
            {
                StaffUser staffUser = new StaffUser();
                staffUser.Designation = "Mr";
                staffUser.Email = "test@test.com";
                staffUser.EnableDst = true;
                staffUser.FirstName = "FirstName";
                staffUser.Greeting = "GreetingText";
                staffUser.GroupId = 1;
                staffUser.IsEnabled = true;
                staffUser.LastName = "LastName";
                staffUser.MobileNumber = "012345678911";
				//Can't test signature as it doesn't come back from the Api
				staffUser.Signature = "My Staff Greeting";
                staffUser.TimeZone = "GMT";
                staffUser.UserName = "teststaff";
                staffUser.FullName = String.Format("{0} {1}", staffUser.FirstName, staffUser.LastName);

                return staffUser;
            }
        }

		[Test]
		public void GetAllStaffUsers()
		{
			StaffUserCollection staffUsers = TestSetup.KayakoApiService.Staff.GetStaffUsers();

            Assert.IsNotNull(staffUsers, "No staff users were returned");
            Assert.IsNotEmpty(staffUsers, "No staff users were returned");
		}

		[Test]
		public void GetStaffUser()
		{
			StaffUserCollection staffUsers = TestSetup.KayakoApiService.Staff.GetStaffUsers();

            Assert.IsNotNull(staffUsers, "No staff users were returned");
            Assert.IsNotEmpty(staffUsers, "No staff users were returned");

			StaffUser staffUserToGet = staffUsers[new Random().Next(staffUsers.Count)];

            Trace.WriteLine("GetStaffUser using staff user id: " + staffUserToGet.Id);

			StaffUser staffUser = TestSetup.KayakoApiService.Staff.GetStaffUser(staffUserToGet.Id);

			CompareStaffUsers(staffUser, staffUserToGet);
		}

        [Test(Description="Tests creating, updating and deleting staff users")]
        public void CreateUpdateDeleteStaffUser()
        {
            StaffUser dummyStaffUser = TestData;

			StaffUserRequest req = StaffUserRequest.FromResponseData(dummyStaffUser);
			req.Password = "password123";

			StaffUser createdStaffUser = TestSetup.KayakoApiService.Staff.CreateStaffUser(req);

            Assert.IsNotNull(createdStaffUser);
			dummyStaffUser.Id = createdStaffUser.Id;
            CompareStaffUsers(dummyStaffUser, createdStaffUser);

            dummyStaffUser.Designation = "Mrs";
            dummyStaffUser.Email = "updatedtest@test.com";
            dummyStaffUser.EnableDst = false;
            dummyStaffUser.FirstName = "UpdatedFirstName";
            dummyStaffUser.Greeting = "UpdatedGreetingtext";
			StaffGroupCollection staffGroups = TestSetup.KayakoApiService.Staff.GetStaffGroups();
            dummyStaffUser.GroupId = staffGroups[staffGroups.Count - 1].Id;
            dummyStaffUser.IsEnabled = false;
            dummyStaffUser.LastName = "UpdatedLastName";
            dummyStaffUser.MobileNumber = "0798765432";
			//Can't test signature as it doesn't come back from the Api
			//dummyStaffUser.Signature = "Signature Updated";
            dummyStaffUser.TimeZone = "GMT BST";
            dummyStaffUser.UserName = "updatedUser";

			StaffUser updatedStaffUser = TestSetup.KayakoApiService.Staff.UpdateStaffUser(StaffUserRequest.FromResponseData(dummyStaffUser));
			dummyStaffUser.FullName = String.Format("{0} {1}", dummyStaffUser.FirstName, dummyStaffUser.LastName);

            Assert.IsNotNull(updatedStaffUser);
            CompareStaffUsers(dummyStaffUser, updatedStaffUser);

            bool success = TestSetup.KayakoApiService.Staff.DeleteStaffUser(updatedStaffUser.Id);

            Assert.IsTrue(success);
        }

        private void CompareStaffUsers(StaffUser one, StaffUser two)
        {
            Assert.AreEqual(one.Designation, two.Designation);
            Assert.AreEqual(one.Email, two.Email);
            Assert.AreEqual(one.EnableDst, two.EnableDst);
            Assert.AreEqual(one.FirstName, two.FirstName);
            Assert.AreEqual(one.FullName, two.FullName);
            Assert.AreEqual(one.Greeting, two.Greeting);
            Assert.AreEqual(one.GroupId, two.GroupId);
            Assert.AreEqual(one.Id, two.Id);
            Assert.AreEqual(one.IsEnabled, two.IsEnabled);
            Assert.AreEqual(one.LastName, two.LastName);
            Assert.AreEqual(one.MobileNumber, two.MobileNumber);
            //Can't test signature as it doesn't come back from the Api
			//Assert.AreEqual(one.Signature, two.Signature);
            Assert.AreEqual(one.TimeZone, two.TimeZone);
            Assert.AreEqual(one.UserName, two.UserName);

			AssertObjectXmlEqual<StaffUser>(one, two);
        }
	}
}
