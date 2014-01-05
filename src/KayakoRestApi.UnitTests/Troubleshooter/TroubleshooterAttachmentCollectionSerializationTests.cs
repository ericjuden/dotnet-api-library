using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.Troubleshooter;
using KayakoRestApi.Data;
using KayakoRestApi.UnitTests.Utilities;
using NUnit.Framework;

namespace KayakoRestApi.UnitTests.Troubleshooter
{
	[TestFixture]
	public class TroubleshooterAttachmentCollectionSerializationTests
	{
		[Test]
		public void TroubleshooterAttachmentCollectionDeserialization()
		{
			var troubleshooterAttachmentCollection = new TroubleshooterAttachmentCollection
				{
					new TroubleshooterAttachment
						{
							Id = 24,
							TroubleshooterStepId = 20,
							FileName = "file.xml",
							FileSize = 45380,
							FileType = "text/xml",
							DateLine = new UnixDateTime(1341315552),
							Contents = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK=="
						},
					new TroubleshooterAttachment
						{
							Id = 26,
							TroubleshooterStepId = 20,
							FileName = "file1.rar",
							FileSize = 3448,
							FileType = "application/rar",
							DateLine = new UnixDateTime(1341315640),
							Contents = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK=="
						}
				};

			var expectedTroubleshooterAttachmentCollection = XmlDataUtility.ReadFromFile<TroubleshooterAttachmentCollection>("TestData/TroubleshooterAttachmentCollection.xml");

			AssertUtility.ObjectsEqual(expectedTroubleshooterAttachmentCollection, troubleshooterAttachmentCollection);
		}
	}
}
