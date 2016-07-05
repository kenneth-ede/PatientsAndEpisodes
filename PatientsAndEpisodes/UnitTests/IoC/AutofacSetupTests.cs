using Autofac;
using NUnit.Framework;
using RestApi.IoC;
using RestApi.Models;

namespace RestApiUnitTests.IoC
{
    [TestFixture]
    public class AutofacSetupTests
    {
        [Test]
        public void ResolveController_UsingInMemoryContext_ExpectPatientsControllerWithInMemoryContext()
        {
            // arrange
            var ioc = new AutofacSetup();

            var expectedContext = typeof (InMemoryContext);

            // act
            var container = ioc.Init(true);

            var actualContext = container.Resolve<IPatientContext>();

            // assert
            Assert.IsInstanceOf(expectedContext, actualContext);
        }

        [Test]
        public void ResolveController_UsingSqlData_ExpectPatientsControllerWithPatientsContext()
        {
            // arrange
            var ioc = new AutofacSetup();

            var expectedContext = typeof (PatientContext);

            // act
            var container = ioc.Init();

            var actualContext = container.Resolve<IPatientContext>();

            // assert
            Assert.IsInstanceOf(expectedContext, actualContext);
        }
    }
}