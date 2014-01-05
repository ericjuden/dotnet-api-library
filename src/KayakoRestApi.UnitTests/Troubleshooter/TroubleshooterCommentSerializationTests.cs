using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.Troubleshooter;
using KayakoRestApi.Data;
using KayakoRestApi.UnitTests.Utilities;
using NUnit.Framework;

namespace KayakoRestApi.UnitTests.Troubleshooter
{
	[TestFixture]
	public class TroubleshooterCommentSerializationTests
	{
		[Test]
		public void TroubleshooterCommentCollectionDeserialization()
		{
			var troubleshooterCommentCollection = new TroubleshooterCommentCollection
				{
					new TroubleshooterComment
						{
							Id = 325,
							TroubleshooterStepId = 20,
							CreatorType = TroubleshooterCommentCreatorType.Staff,
							CreatorId = 1,
							FullName = "Jon doe",
							Email = "",
							IpAddress = "127.0.0.1",
							DateLine = new UnixDateTime(1341311488),
							ParentCommentId = 0,
							CommentStatus = TroubleshooterCommentStatus.MarkedAsSpam,
							UserAgent = "",
							Referrer = "",
							ParentUrl = "",
							Contents = "Contents"
						},
					new TroubleshooterComment
						{
							Id = 326,
							TroubleshooterStepId = 20,
							CreatorType = TroubleshooterCommentCreatorType.User,
							CreatorId = 1,
							FullName = "Mark",
							Email = "",
							IpAddress = "127.0.0.1",
							DateLine = new UnixDateTime(1341311488),
							ParentCommentId = 0,
							CommentStatus = TroubleshooterCommentStatus.PendingForApproval,
							UserAgent = "",
							Referrer = "",
							ParentUrl = "",
							Contents = "Contents of a comment"
						}
				};

			var expectedTroubleshooterCommentCollection = XmlDataUtility.ReadFromFile<TroubleshooterCommentCollection>("TestData/TroubleshooterCommentCollection.xml");

			AssertUtility.ObjectsEqual(expectedTroubleshooterCommentCollection, troubleshooterCommentCollection);
		}
	}
}
