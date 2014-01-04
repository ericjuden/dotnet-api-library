using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.Troubleshooter;
using KayakoRestApi.UnitTests.Utilities;
using NUnit.Framework;

namespace KayakoRestApi.UnitTests.Troubleshooter
{
	[TestFixture]
	public class TroubleshooterStepsCollectionSerializationTests
	{
		[Test]
		public void TroubleshooterStepsCollectionDeserialization()
		{
			var troubleshooterStepsCollection = new TroubleshooterStepCollection
				{
					new TroubleshooterStep
						{
							Id = 25,
							CategoryId = TroubleshooterCategoryType.Global,
							StaffId = 1,
							StaffName = "admin admin",
							Subject = "Troubleshooter step subject",
							Edited = false,
							EditedStaffId = 0,
							EditedStaffName = "",
							DisplayOrder = 15,
							Views = 0,
							AllowComments = true,
							HasAttachments = false,
							Attachments = new []
							{
								new TroubleshooterStepAttachment
								{
									Id = 3,
									FileName = "attachement.txt",
									FileSize = "0.01 KB",
									Link = "http://jamietestingagain.kayako.com/api/Troubleshooter/Step/GetAttachment/1/1/3"
								}
							},
							ParentSteps = new [] { 0 },
							ChildSteps = new int[0],
							RedirectTickets = true,
							TicketSubject = "",
							RedirectDepartmentId = 0,
							TicketTypeId = 0,
							PriorityId = 0,
							Contents = "Troubleshooter step contents"
						},
					new TroubleshooterStep
						{
							Id = 28,
							CategoryId = TroubleshooterCategoryType.Global,
							StaffId = 1,
							StaffName = "admin admin",
							Subject = "Troubleshooter subject",
							Edited = false,
							EditedStaffId = 0,
							EditedStaffName = "",
							DisplayOrder = 17,
							Views = 0,
							AllowComments = true,
							HasAttachments = false,
							ParentSteps = new [] { 0 },
							ChildSteps = new int[0],
							RedirectTickets = true,
							TicketSubject = "",
							RedirectDepartmentId = 0,
							TicketTypeId = 0,
							PriorityId = 0,
							Contents = "Troubleshooter step contents"
						}
				};

			var expectedTroubleshooterStepCollection = XmlDataUtility.ReadFromFile<TroubleshooterStepCollection>("TestData/TroubleshooterStepsCollection.xml");

			AssertUtility.ObjectsEqual(expectedTroubleshooterStepCollection, troubleshooterStepsCollection);
		}
	}
}
