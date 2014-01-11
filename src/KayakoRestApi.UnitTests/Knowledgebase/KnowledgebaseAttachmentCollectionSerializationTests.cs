using KayakoRestApi.Core.Knowledgebase;
using KayakoRestApi.Data;
using KayakoRestApi.UnitTests.Utilities;
using NUnit.Framework;

namespace KayakoRestApi.UnitTests.Knowledgebase
{
	[TestFixture]
	public class KnowledgebaseAttachmentCollectionSerializationTests
	{
		[Test]
		public void KnowledgebaseAttachmentCollectionDeserialization()
		{
			var knowledgebaseAttachmentCollection = new KnowledgebaseAttachmentCollection
				{
					new KnowledgebaseAttachment
						{
							Id = 4,
							KnowledgebaseArticleId = 1,
							FileName = "image.jpg",
							FileSize = 90543,
							FileType = "image/jpeg",
							DateLine = new UnixDateTime(1335819066),
							Contents = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK=="
						},
					new KnowledgebaseAttachment
						{
							Id = 4,
							KnowledgebaseArticleId = 1,
							FileName = "image1.jpg",
							FileSize = 90549,
							FileType = "image/jpeg",
							DateLine = new UnixDateTime(1335819066),
							Contents = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK=="
						}
				};

			var expectedKnowledgebaseAttachmentCollection = XmlDataUtility.ReadFromFile<KnowledgebaseAttachmentCollection>("TestData/KnowledgebaseAttachmentCollection.xml");

			AssertUtility.ObjectsEqual(expectedKnowledgebaseAttachmentCollection, knowledgebaseAttachmentCollection);
		}
	}
}
