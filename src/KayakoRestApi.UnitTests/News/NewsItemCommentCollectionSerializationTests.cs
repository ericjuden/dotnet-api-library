using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.News;
using KayakoRestApi.Data;
using KayakoRestApi.UnitTests.Utilities;
using NUnit.Framework;

namespace KayakoRestApi.UnitTests.News
{
	[TestFixture]
	public class NewsItemCommentCollectionSerializationTests
	{
		[Test]
		public void NewsItemCommentCollectionDeserialization()
		{
			var newsItemCommentCollection = new NewsItemCommentCollection
				{
					new NewsItemComment
						{
							Id = 320,
							NewsItemId = 41,
							CreatorType = NewsItemCommentCreatorType.User,
							CreatorId = 1,
							FullName = "Jon doe",
							Email = "",
							IpAddress = "127.0.0.1",
							DateLine = new UnixDateTime(1340037804),
							ParentCommentId = 0,
							CommentStatus = NewsItemCommentStatus.Approved,
							UserAgent = "",
							Referrer = "",
							ParentUrl = "",
							Contents = "Created by API on news"
						},
					new NewsItemComment
						{
							Id = 321,
							NewsItemId = 41,
							CreatorType = NewsItemCommentCreatorType.User,
							CreatorId = 1,
							FullName = "Simaranjit Singh",
							Email = "",
							IpAddress = "127.0.0.1",
							DateLine = new UnixDateTime(1340037801),
							ParentCommentId = 0,
							CommentStatus = NewsItemCommentStatus.Approved,
							UserAgent = "",
							Referrer = "",
							ParentUrl = "",
							Contents = "Created by API on news"
						}
				};

			var expectedNewsItemCommentCollection = XmlDataUtility.ReadFromFile<NewsItemCommentCollection>("TestData/NewsItemCommentCollection.xml");

			AssertUtility.ObjectsEqual(expectedNewsItemCommentCollection, newsItemCommentCollection);
		}
	}
}
