using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Configuration;
using KayakoRestApi;
using System.Diagnostics;
using KayakoRestApi.Core.Users;
using KayakoRestApi.Core.Constants;

namespace KayakoRestApi.IntegrationTests
{
	[TestFixture(Description = "A set of tests testing Api methods around User Groups")]
	public class UserGroupTests : UnitTestBase
	{
		private UserGroup TestData
        {
            get
            {
				UserGroup testUserGroup = new UserGroup();
				testUserGroup.GroupType = UserGroupType.Guest;
				testUserGroup.IsMaster = false;
				testUserGroup.Title = "Title User Group";

                return testUserGroup;
            }
        }

		[Test]
		public void GetAllGetUserGroups()
		{
			UserGroupCollection userOrganizations = TestSetup.KayakoApiService.Users.GetUserGroups();

			Assert.IsNotNull(userOrganizations, "No user groups were returned");
			Assert.IsNotEmpty(userOrganizations, "No user groups were returned");
		}

		[Test]
		public void GetUserGroup()
		{
			UserGroupCollection userGroups = TestSetup.KayakoApiService.Users.GetUserGroups();

			Assert.IsNotNull(userGroups, "No user groups were returned");
			Assert.IsNotEmpty(userGroups, "No user groups were returned");

			UserGroup userGroupToGet = userGroups[new Random().Next(userGroups.Count)];

			Trace.WriteLine("GetUserGroup using user group id: " + userGroupToGet.Id);

			UserGroup userGroup = TestSetup.KayakoApiService.Users.GetUserGroup(userGroupToGet.Id);

			CompareUserGroup(userGroup, userGroupToGet);
		}

        [Test(Description="Tests creating, updating and deleting user groups")]
        public void CreateUpdateDeleteUserGroup()
        {
			UserGroup dummyData = TestData;

			UserGroup createdUserGroup = TestSetup.KayakoApiService.Users.CreateUserGroup(UserGroupRequest.FromResponseData(dummyData));

            Assert.IsNotNull(createdUserGroup);
            dummyData.Id = createdUserGroup.Id;
            CompareUserGroup(dummyData, createdUserGroup);

			dummyData.Title = "UPDATED: User Group Title";

            UserGroup updatedUserGroup = TestSetup.KayakoApiService.Users.UpdateUserGroup(UserGroupRequest.FromResponseData(dummyData));

            Assert.IsNotNull(updatedUserGroup);
            CompareUserGroup(dummyData, updatedUserGroup);

            bool success = TestSetup.KayakoApiService.Users.DeleteUserGroup(updatedUserGroup.Id);

            Assert.IsTrue(success);
        }

		private void CompareUserGroup(UserGroup one, UserGroup two)
        {
            Assert.AreEqual(one.GroupType, two.GroupType);
			Assert.AreEqual(one.Id, two.Id);
			Assert.AreEqual(one.IsMaster, two.IsMaster);
			Assert.AreEqual(one.Title, two.Title);

			AssertObjectXmlEqual<UserGroup>(one, two);
        }
	}
}
