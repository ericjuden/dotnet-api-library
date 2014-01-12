using System;
using System.Diagnostics;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.Troubleshooter;
using NUnit.Framework;

namespace KayakoRestApi.IntegrationTests.Troubleshooter
{
	[TestFixture]
	public class TroubleshooterStepTests : UnitTestBase
	{
		[Test]
		public void GetAllTroubleshooterSteps()
		{
			TroubleshooterStepCollection troubleshooterSteps = TestSetup.KayakoApiService.Troubleshooter.GetTroubleshooterSteps();

			Assert.IsNotNull(troubleshooterSteps, "No troubleshooter steps were returned");
			Assert.IsNotEmpty(troubleshooterSteps, "No troubleshooter steps were returned");
		}

		[Test]
		public void GetTroubleshooterStep()
		{
			TroubleshooterStepCollection troubleshooterSteps = TestSetup.KayakoApiService.Troubleshooter.GetTroubleshooterSteps();

			Assert.IsNotNull(troubleshooterSteps, "No troubleshooter steps were returned");
			Assert.IsNotEmpty(troubleshooterSteps, "No troubleshooter steps were returned");

			TroubleshooterStep troubleshooterStepToGet = troubleshooterSteps[new Random().Next(troubleshooterSteps.Count)];

			Trace.WriteLine("GetTroubleshooterStep using troubleshooter step id: " + troubleshooterStepToGet.Id);

			TroubleshooterStep troubleshooterStep = TestSetup.KayakoApiService.Troubleshooter.GetTroubleshooterStep(troubleshooterStepToGet.Id);

			AssertObjectXmlEqual(troubleshooterStep, troubleshooterStepToGet);
		}

		[Test(Description = "Tests creating, updating and deleting troubleshooter steps")]
		public void CreateUpdateDeleteNewsStep()
		{
			TroubleshooterStepRequest troubleshooterStepRequest = new TroubleshooterStepRequest
				{
					CategoryId = 1,
					Subject = "Subject",
					Contents = "Contents",
					StaffId = 1,
					DisplayOrder = 23,
					AllowComments = true,
					EnableTicketRedirection = false,
					RedirectDepartmentId = 1,
					TicketTypeId = 1,
					TicketPriorityId = 1,
					TicketSubject = "TicketSubject",
					StepStatus = TroubleshooterStepStatus.Draft,
					ParentStepIdList = new [] { 0 }
				};

			var troubleshooterStep = TestSetup.KayakoApiService.Troubleshooter.CreateTroubleshooterStep(troubleshooterStepRequest);

			Assert.IsNotNull(troubleshooterStep);
			Assert.That(troubleshooterStep.CategoryId, Is.EqualTo(troubleshooterStepRequest.CategoryId));
			Assert.That(troubleshooterStep.Subject, Is.EqualTo(troubleshooterStepRequest.Subject));
			Assert.That(troubleshooterStep.Contents, Is.EqualTo(troubleshooterStepRequest.Contents));
			Assert.That(troubleshooterStep.StaffId, Is.EqualTo(troubleshooterStepRequest.StaffId));
			Assert.That(troubleshooterStep.DisplayOrder, Is.EqualTo(troubleshooterStepRequest.DisplayOrder));
			Assert.That(troubleshooterStep.AllowComments, Is.EqualTo(troubleshooterStepRequest.AllowComments));
			Assert.That(troubleshooterStep.RedirectTickets, Is.EqualTo(troubleshooterStepRequest.EnableTicketRedirection));
			Assert.That(troubleshooterStep.RedirectDepartmentId, Is.EqualTo(troubleshooterStepRequest.RedirectDepartmentId));
			Assert.That(troubleshooterStep.TicketTypeId, Is.EqualTo(troubleshooterStepRequest.TicketTypeId));
			Assert.That(troubleshooterStep.TicketPriorityId, Is.EqualTo(troubleshooterStepRequest.TicketPriorityId));
			//Assert.That(troubleshooterStep.TicketSubject, Is.EqualTo(troubleshooterStepRequest.TicketSubject));
			Assert.That(troubleshooterStep.ParentSteps, Is.EqualTo(troubleshooterStepRequest.ParentStepIdList));

			troubleshooterStepRequest.Id = troubleshooterStep.Id;
			troubleshooterStepRequest.Subject += "_Title";
			troubleshooterStepRequest.DisplayOrder = 21;

			troubleshooterStep = TestSetup.KayakoApiService.Troubleshooter.UpdateTroubleshooterStep(troubleshooterStepRequest);

			Assert.IsNotNull(troubleshooterStep);
			Assert.That(troubleshooterStep.Subject, Is.EqualTo(troubleshooterStepRequest.Subject));
			Assert.That(troubleshooterStep.DisplayOrder, Is.EqualTo(troubleshooterStepRequest.DisplayOrder));

			var deleteResult = TestSetup.KayakoApiService.Troubleshooter.DeleteTroubleshooterStep(troubleshooterStepRequest.Id);
			Assert.IsTrue(deleteResult);
		}
	}
}
