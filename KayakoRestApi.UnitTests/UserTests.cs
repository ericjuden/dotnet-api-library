using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Configuration;
using KayakoRestApi;
using System.Diagnostics;
using KayakoRestApi.Core.Users;
using KayakoRestApi.Data;
using KayakoRestApi.Utilities;
using KayakoRestApi.Core.Constants;

namespace KayakoRestApi.UnitTests
{
	[TestFixture(Description = "A set of tests testing Api methods around Users")]
	public class UserTests : UnitTestBase
	{
        private User TestData
        {
            get
            {
                User testUser = new User();
				testUser.Dateline = UnixTimeUtility.ToUnixTime(DateTime.Now);
                testUser.Designation = "CEO";
                testUser.EmailAddresses = new string[] { "test1@test.com" };
                testUser.EnableDst = true;
                testUser.Expiry = 0;
                testUser.FullName = "Full Name";
                testUser.GroupId = 2;
                testUser.IsEnabled = true;
                testUser.OrganizationId = 1;
                testUser.Phone = "01234567890";
                testUser.Role = UserRole.Manager;
                testUser.Salutation = UserSalutation.Dr;
                testUser.SlaPlanExpiry = 0;
                testUser.SlaPlanId = 1;
                testUser.TimeZone = "GMT";

                return testUser;
            }
        }

		[Test]
		public void GetAllGetUsers()
		{
			UserCollection users = TestSetup.KayakoApiService.Users.GetUsers();
			
			Assert.IsNotNull(users, "No users were returned");
			Assert.IsNotEmpty(users, "No users were returned");
		}

		[Test]
		public void GetUser()
		{
			UserCollection users = TestSetup.KayakoApiService.Users.GetUsers();

			Assert.IsNotNull(users, "No users were returned");
			Assert.IsNotEmpty(users, "No users  were returned");

			User userToGet = users[new Random().Next(users.Count)];

            Trace.WriteLine("GetUser using user id: " + userToGet.Id);

			User user = TestSetup.KayakoApiService.Users.GetUser(userToGet.Id);

			CompareUserGroup(user, userToGet);
		}

        [Test(Description="Tests creating, updating and deleting users")]
        public void CreateUpdateDeleteUser()
        {
            User dummyData = TestData;

            User createdUser = TestSetup.KayakoApiService.Users.CreateUser(UserRequest.FromResponseData(dummyData), "password123!", false);

            Assert.IsNotNull(createdUser);
            dummyData.Id = createdUser.Id;
			dummyData.Dateline = createdUser.Dateline;

			CompareUserGroup(dummyData, createdUser);

			dummyData.FullName = "Updated FullName";
			dummyData.EmailAddresses = new string[] { "test1@test.com", "test2@test.com" };
			dummyData.Salutation = UserSalutation.Mrs;
			dummyData.Designation = "CGE";
			dummyData.Phone = "09876543212";
			dummyData.IsEnabled = false;
			dummyData.Role = UserRole.User;
			
            User updatedUser = TestSetup.KayakoApiService.Users.UpdateUser(UserRequest.FromResponseData(dummyData));
			dummyData.Dateline = createdUser.Dateline;

            Assert.IsNotNull(updatedUser);
            CompareUserGroup(dummyData, updatedUser);

            bool success = TestSetup.KayakoApiService.Users.DeleteUser(updatedUser.Id);

            Assert.IsTrue(success);
        }

        private void CompareUserGroup(User one, User two)
        {
            Assert.IsTrue(one.Dateline.Equals(two.Dateline), "Dateline is not the same");
            Assert.AreEqual(one.Designation, two.Designation);
            Assert.AreEqual(one.EmailAddresses, two.EmailAddresses);
            Assert.AreEqual(one.EnableDst, two.EnableDst);
            Assert.AreEqual(one.Expiry, two.Expiry);
            Assert.AreEqual(one.FullName, two.FullName);
            Assert.AreEqual(one.GroupId, two.GroupId);
            Assert.AreEqual(one.Id, two.Id);
            Assert.AreEqual(one.IsEnabled, two.IsEnabled);
            Assert.AreEqual(one.LastVisit, two.LastVisit);
			
			if (one.OrganizationId != null && one.OrganizationId.HasValue)
			{
				Assert.AreEqual(one.OrganizationId.Value, two.OrganizationId.Value);
			}

            Assert.AreEqual(one.Phone, two.Phone);
            Assert.AreEqual(one.Role, two.Role);
            Assert.AreEqual(one.Salutation, two.Salutation);
            Assert.AreEqual(one.SlaPlanExpiry, two.SlaPlanExpiry);
            Assert.AreEqual(one.SlaPlanId, two.SlaPlanId);
            Assert.AreEqual(one.TimeZone, two.TimeZone);
            
            AssertObjectXmlEqual<User>(one, two);
        }
	}
}
