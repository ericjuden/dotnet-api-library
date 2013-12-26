using System;
using KayakoRestApi.Controllers;
using KayakoRestApi.Core.Constants;
using KayakoRestApi.Core.Test;
using KayakoRestApi.Net;
using Moq;
using NUnit.Framework;

namespace KayakoRestApi.UnitTests.Core
{
	[TestFixture(Description = "A set of tests testing Api methods around Cusom Fields")]
	public class CoreControllerTests
	{
		private ICoreController _coreController;
		private Mock<IKayakoApiRequest> _kayakoApiRequest;

		private TestData _getTestData;

		[SetUp]
		public void SetUp()
		{
			_kayakoApiRequest = new Mock<IKayakoApiRequest>();
			_coreController = new CoreController(_kayakoApiRequest.Object);

			_getTestData = new TestData("Test");
		}

		[Test]
		public void GetList()
		{
			_kayakoApiRequest.Setup(x => x.ExecuteGet<TestData>(ApiBaseMethods.CoreTest)).Returns(_getTestData);
			var getListResult = _coreController.GetListTest();

			_kayakoApiRequest.Verify(x => x.ExecuteGet<TestData>(ApiBaseMethods.CoreTest), Times.Once());
			Assert.That(getListResult, Is.EqualTo(_getTestData.Data));
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void Get(int id)
		{
			string apiMethod = String.Format("{0}/{1}", ApiBaseMethods.CoreTest, id);
			_kayakoApiRequest.Setup(x => x.ExecuteGet<TestData>(apiMethod)).Returns(_getTestData);

			var getResult = _coreController.GetTest(id);

			_kayakoApiRequest.Verify(x => x.ExecuteGet<TestData>(apiMethod), Times.Once());
			Assert.That(getResult, Is.EqualTo(_getTestData.Data));
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void Put(int id)
		{
			string apiMethod = String.Format("{0}/{1}", ApiBaseMethods.CoreTest, id);
			_kayakoApiRequest.Setup(x => x.ExecutePut<TestData>(apiMethod, "")).Returns(_getTestData);

			var putResult = _coreController.PutTest(id);
			
			_kayakoApiRequest.Verify(x => x.ExecutePut<TestData>(apiMethod, ""), Times.Once());
			Assert.That(putResult, Is.EqualTo(_getTestData.Data));
		}

		[Test]
		public void Post()
		{
			_kayakoApiRequest.Setup(x => x.ExecutePost<TestData>(ApiBaseMethods.CoreTest, "")).Returns(_getTestData);

			var postResult = _coreController.PostTest();

			_kayakoApiRequest.Verify(x => x.ExecutePost<TestData>(ApiBaseMethods.CoreTest, ""), Times.Once());
			Assert.That(postResult, Is.EqualTo(_getTestData.Data));
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void Delete(int id)
		{
			string apiMethod = String.Format("{0}/{1}", ApiBaseMethods.CoreTest, id);
			_kayakoApiRequest.Setup(x => x.ExecuteDelete(apiMethod)).Returns(true);

			var deleteResult = _coreController.DeleteTest(id);

			_kayakoApiRequest.Verify(x => x.ExecuteDelete(apiMethod), Times.Once());
			Assert.That(deleteResult, Is.EqualTo(true));
		}
	}
}
