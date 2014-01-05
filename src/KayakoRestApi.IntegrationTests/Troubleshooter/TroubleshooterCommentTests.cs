using System;
using System.Diagnostics;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.Troubleshooter;
using NUnit.Framework;

namespace KayakoRestApi.IntegrationTests.Troubleshooter
{
	[TestFixture]
	public class TroubleshooterCommentTests : UnitTestBase
	{
		[Test]
		public void GetAllTroubleshooterComments()
		{
			TroubleshooterStepCollection troubleshooterSteps = TestSetup.KayakoApiService.Troubleshooter.GetTroubleshooterSteps();

			Assert.IsNotNull(troubleshooterSteps, "No troubleshooter steps were returned");
			Assert.IsNotEmpty(troubleshooterSteps, "No troubleshooter steps were returned");

			TroubleshooterStep troubleshooterStepToGet = troubleshooterSteps[new Random().Next(troubleshooterSteps.Count)];

			TroubleshooterCommentCollection troubleshooterComments = TestSetup.KayakoApiService.Troubleshooter.GetTroubleshooterComments(troubleshooterStepToGet.Id);

			Assert.IsNotNull(troubleshooterComments, "No troubleshooter comments were returned");
			Assert.IsNotEmpty(troubleshooterComments, "No troubleshooter comments were returned");
		}

		[Test]
		public void GetTroubleshooterComment()
		{
			TroubleshooterStepCollection troubleshooterSteps = TestSetup.KayakoApiService.Troubleshooter.GetTroubleshooterSteps();

			Assert.IsNotNull(troubleshooterSteps, "No troubleshooter steps were returned");
			Assert.IsNotEmpty(troubleshooterSteps, "No troubleshooter steps were returned");

			TroubleshooterStep troubleshooterStepToGet = troubleshooterSteps[new Random().Next(troubleshooterSteps.Count)];

			TroubleshooterCommentCollection troubleshooterComments = TestSetup.KayakoApiService.Troubleshooter.GetTroubleshooterComments(troubleshooterStepToGet.Id);

			Assert.IsNotNull(troubleshooterComments, "No troubleshooter comments were returned");
			Assert.IsNotEmpty(troubleshooterComments, "No troubleshooter comments were returned");

			TroubleshooterComment troubleshooterCommentToGet = troubleshooterComments[new Random().Next(troubleshooterComments.Count)];

			Trace.WriteLine("GetTroubleshooterCategory using troubleshooter comment id: " + troubleshooterCommentToGet.Id);

			TroubleshooterComment troubleshooterComment = TestSetup.KayakoApiService.Troubleshooter.GetTroubleshooterComment(troubleshooterCommentToGet.Id);

			AssertObjectXmlEqual(troubleshooterComment, troubleshooterCommentToGet);
		}

		[Test(Description = "Tests creating and deleting troubleshooter comments")]
		public void CreateDeleteNewsComment()
		{
			TroubleshooterCommentRequest troubleshooterCommentRequest = new TroubleshooterCommentRequest
			{
				TroubleshooterStepId = 1,
				Contents = "Contents",
				CreatorType = TroubleshooterCommentCreatorType.Staff,
				Email = "",
				CreatorId = 1
			};

			var troubleshooterComment = TestSetup.KayakoApiService.Troubleshooter.CreateTroubleshooterComment(troubleshooterCommentRequest);

			Assert.IsNotNull(troubleshooterComment);
			Assert.That(troubleshooterComment.TroubleshooterStepId, Is.EqualTo(troubleshooterCommentRequest.TroubleshooterStepId));
			Assert.That(troubleshooterComment.Contents, Is.EqualTo(troubleshooterCommentRequest.Contents));
			Assert.That(troubleshooterComment.CreatorType, Is.EqualTo(troubleshooterCommentRequest.CreatorType));
			Assert.That(troubleshooterComment.Email, Is.EqualTo(troubleshooterCommentRequest.Email));
			Assert.That(troubleshooterComment.CreatorId, Is.EqualTo(troubleshooterCommentRequest.CreatorId));

			var deleteResult = TestSetup.KayakoApiService.Troubleshooter.DeleteTroubleshooterComment(troubleshooterComment.Id);
			Assert.IsTrue(deleteResult);
		}
	}
}
