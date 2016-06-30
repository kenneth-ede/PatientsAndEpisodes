using NUnit.Framework;
using System.Web.Http;
using Autofac;
using RestApi.IoC;

namespace RestApiUnitTests.IoC
{
    [TestFixture]
    public class AutofacTests
    {
        [Test]
        public void ResolveController_UsingDependencyContainer_ExpectPatientsControllerAndDependencies()
        {
            // arrange
            var ioc = new RestApi.IoC.AutofacInit();

            var expected = typeof(RestApi.Controllers.PatientsController);

            // act
            var actual = AutofacInit.Container.Resolve<RestApi.Controllers.PatientsController>();

            // assert
            Assert.IsInstanceOf(expected, actual);
        }
    }
}
