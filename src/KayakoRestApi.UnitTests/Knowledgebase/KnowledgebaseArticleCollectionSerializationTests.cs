using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.Knowledgebase;
using KayakoRestApi.Data;
using KayakoRestApi.UnitTests.Utilities;
using NUnit.Framework;

namespace KayakoRestApi.UnitTests.Knowledgebase
{
	[TestFixture]
	public class KnowledgebaseArticleCollectionSerializationTests
	{
		[Test]
		public void KnowledgebaseArticleCollectionDeserialization()
		{
			var knowledgebaseArticleCollection = new KnowledgebaseArticleCollection
				{
					new KnowledgebaseArticle
						{
							Id = 1,
							Contents = "Contents",
							ContentsText = "Contents",
							Categories = new [] { 0 },
							Creator = 2,
							CreatorId = 1,
							Author = "Simaranjit Singh",
							Email = "email@domain.com",
							Subject = "Subject",
							IsEdited = true,
							EditedDateLine = new UnixDateTime(1336757517),
							EditedStaffId = 1,
							Views = 24,
							IsFeatured = false,
							AllowComments = true,
							TotalComments = 0,
							HasAttachments = true,
							Attachments = new []
								{
									new KnowledgebaseArticleAttachment
										{
											Id = 4,
											FileName = "photo.jpg",
											FileSize = "88.42 KB",
											Link = ""
										},
									new KnowledgebaseArticleAttachment
										{
											Id = 5,
											FileName = "cap_ture1.png",
											FileSize = "8.99 KB",
											Link = ""
										},
									new KnowledgebaseArticleAttachment
										{
											Id = 20,
											FileName = "abcde.txt",
											FileSize = "0.00 KB",
											Link = ""
										}
								},
							DateLine = new UnixDateTime(1335437662),
							ArticleStatus = KnowledgebaseArticleStatus.Published,
							ArticleRating = 0,
							RatingHits = 0,
							RatingCount = 0
						}
				};

			var expectedKnowledgebaseArticleCollection = XmlDataUtility.ReadFromFile<KnowledgebaseArticleCollection>("TestData/KnowledgebaseArticleCollection.xml");

			AssertUtility.ObjectsEqual(expectedKnowledgebaseArticleCollection, knowledgebaseArticleCollection);
		}
	}
}
