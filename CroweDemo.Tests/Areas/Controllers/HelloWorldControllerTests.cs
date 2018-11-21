using System;
using System.Web.Mvc;
using CroweDemo.Web.Areas.Demo.Controllers;
using CroweDemo.Web.Areas.Demo.Models.Base;
using CroweDemo.Web.Areas.Demo.Models.Pages;
using NSubstitute;
using NUnit.Framework;


namespace CroweDemo.Tests.Areas.Controllers
{
    public class HelloWorldControllerTestHarness : GlassControllerTestHarnessBase
    {
        public HelloWorldControllerTestHarness() 
        {
            HelloWorldController = new HelloWorldController(RequestContext, GlassHtml, RenderingContext, HttpContext);
        }

        public HelloWorldController HelloWorldController { get; }
        
    }

    [TestFixture]
    public class HelloWorldUnitTests
    {
        public HelloWorldControllerTestHarness testHarness { get; set; }

        [Test]
        public void Index_ContextItemIsNull_EmptyResultReturned()
        {
            // Given

            var expectedViewModel = new HelloWorld();
            testHarness = new HelloWorldControllerTestHarness();
            testHarness.RequestContext.GetContextItem<IHelloWorld>().Returns(expectedViewModel);

            // When
            var result = testHarness.HelloWorldController.Index();

            // Then
            Assert.IsNotNull(result);
            Assert.IsTrue(result is EmptyResult, "result is not EmptyResult");
        }

        [Test]
        public void Index_ContextItemIsNotNull_ModelTopHeaderContentEqualsCurrentPage()
        {
            // Given
            var currentPageItemId = Guid.NewGuid();
            var expectedViewModel = Substitute.For<IHelloWorld>();
            var currentPageModel = Substitute.For<IBasePage>();
            expectedViewModel.Id.Returns(currentPageItemId);
            expectedViewModel.CurrentPage.Returns(currentPageModel);
            testHarness = new HelloWorldControllerTestHarness();
            testHarness.RequestContext.GetContextItem<IHelloWorld>().Returns(expectedViewModel);

            // When
            var result = testHarness.HelloWorldController.Index();

            // Then
            Assert.IsNotNull(result);
            Assert.IsTrue(result is ViewResult, "result is not ViewResult");
            var viewResult = result as ViewResult;
            var model = viewResult.Model as IHelloWorld;
            Assert.IsNotNull(model, "model in ViewResult is null");
            Assert.IsNotNull(model.CurrentPage, "model.CurrentPage in ViewResult is null");
        }
    }
}
