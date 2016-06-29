using NUnit.Framework;
using System.Web.Http;

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
            var actual = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ApiController));

            // assert
            Assert.IsInstanceOf(expected, actual);
        }
    }
}
