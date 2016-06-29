using NUnit.Framework;

namespace RestApiUnitTests.IoC
{
    [TestFixture]
    public class AutofacTests
    {
        [Test]
        public void ResolveController_UsingDependencyContainer_ExpectPatientsControllerAndDependencies()
        {
            // arrange

            // act
            var actual = 1; //RestApi.IoC.AutofacInit();

            // assert
            Assert.IsInstanceOf(typeof(RestApi.Controllers.PatientsController), actual);
        }
    }
}
