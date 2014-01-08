using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.Knowledgebase;
using KayakoRestApi.Data;
using KayakoRestApi.UnitTests.Utilities;
using NUnit.Framework;

namespace KayakoRestApi.UnitTests.Knowledgebase
{
	[TestFixture]
	public class KnowledgebaseCommentSerializationTests
	{
		[Test]
		public void KnowledgebaseCommentCollectionDeserialization()
		{
			var knowledgebaseCommentCollection = new KnowledgebaseCommentCollection
				{
					new KnowledgebaseComment
						{
							Id = 17,
							KnowledgebaseArticleId = 1,
							CreatorType = KnowledgebaseCommentCreatorType.User,
							CreatorId = 1,
							FullName = "Simaranjit Singh",
							Email = "",
							IpAddress = "127.0.0.1",
							DateLine = new UnixDateTime(1339786410),
							ParentCommentId = 0,
							CommentStatus = KnowledgebaseCommentStatus.Approved,
							UserAgent = "",
							Referrer = "",
							ParentUrl = "",
							Contents = "Comment1"
						},
					new KnowledgebaseComment
						{
							Id = 19,
							KnowledgebaseArticleId = 1,
							CreatorType = KnowledgebaseCommentCreatorType.User,
							CreatorId = 0,
							FullName = "John",
							Email = "john@domain.com",
							IpAddress = "::1",
							DateLine = new UnixDateTime(1339787502),
							ParentCommentId = 0,
							CommentStatus = KnowledgebaseCommentStatus.Approved,
							UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:13.0) Gecko/20100101 Firefox/13.0",
							Referrer = "",
							ParentUrl = "",
							Contents = "Comment2"
						}
				};

			var expectedKnowledgebaseCommentCollection = XmlDataUtility.ReadFromFile<KnowledgebaseCommentCollection>("TestData/KnowledgebaseCommentCollection.xml");

			AssertUtility.ObjectsEqual(expectedKnowledgebaseCommentCollection, knowledgebaseCommentCollection);
		}
	}
}
