using System;
using System.Linq;
using System.Text;
using KayakoRestApi.Core.Troubleshooter;
using NUnit.Framework;

namespace KayakoRestApi.IntegrationTests.Troubleshooter
{
	[TestFixture]
	public class TroubleshooterAttachmentTests : UnitTestBase
	{
		[Test]
		public void GetTroubleshooterAttachments()
		{
			var troubleshooterSteps = TestSetup.KayakoApiService.Troubleshooter.GetTroubleshooterSteps();

			Assert.IsNotNull(troubleshooterSteps);
			Assert.IsNotEmpty(troubleshooterSteps);

			var troubleshooterStepToGet = troubleshooterSteps.FirstOrDefault();

			Assert.IsNotNull(troubleshooterStepToGet);
			Assert.IsNotNull(troubleshooterStepToGet.Attachments);
			Assert.IsNotEmpty(troubleshooterStepToGet.Attachments);

			var troubleshooterAttachments = TestSetup.KayakoApiService.Troubleshooter.GetTroubleshooterAttachments(troubleshooterStepToGet.Id);

			Assert.IsNotNull(troubleshooterAttachments);
			Assert.IsNotEmpty(troubleshooterAttachments);
			Assert.That(troubleshooterAttachments.Count, Is.EqualTo(troubleshooterStepToGet.Attachments.Length));
		}

		[Test]
		public void GetTroubleshooterAttachment()
		{
			var troubleshooterSteps = TestSetup.KayakoApiService.Troubleshooter.GetTroubleshooterSteps();

			Assert.IsNotNull(troubleshooterSteps);
			Assert.IsNotEmpty(troubleshooterSteps);

			var troubleshooterStepToGet = troubleshooterSteps.FirstOrDefault();

			Assert.IsNotNull(troubleshooterStepToGet);
			Assert.IsNotNull(troubleshooterStepToGet.Attachments);
			Assert.IsNotEmpty(troubleshooterStepToGet.Attachments);

			var troubleshooterAttachment = TestSetup.KayakoApiService.Troubleshooter.GetTroubleshooterAttachment(troubleshooterStepToGet.Id, troubleshooterStepToGet.Attachments.FirstOrDefault().Id);

			Assert.IsNotNull(troubleshooterAttachment);
		}

		[Test]
		public void CreateDeleteTroubleshooterAttachment()
		{
			string contents = Convert.ToBase64String(Encoding.UTF8.GetBytes("This is the contents"));

			var troubleshooterAttachmentRequest = new TroubleshooterAttachmentRequest
				{
					TroubleshooterStepId = 1,
					FileName = "Test.txt",
					Contents = contents
				};

			var troubleshooterAttachment = TestSetup.KayakoApiService.Troubleshooter.CreateTroubleshooterAttachment(troubleshooterAttachmentRequest);
			
			Assert.IsNotNull(troubleshooterAttachment);
			Assert.That(troubleshooterAttachment.TroubleshooterStepId, Is.EqualTo(troubleshooterAttachment.TroubleshooterStepId));
			Assert.That(troubleshooterAttachment.FileName, Is.EqualTo(troubleshooterAttachment.FileName));
			Assert.That(troubleshooterAttachment.Contents, Is.EqualTo(contents));

			var deleteSuccess = TestSetup.KayakoApiService.Troubleshooter.DeleteTroubleshooterAttachment(troubleshooterAttachment.TroubleshooterStepId, troubleshooterAttachment.Id);

			Assert.IsTrue(deleteSuccess);
		}
	}
}
