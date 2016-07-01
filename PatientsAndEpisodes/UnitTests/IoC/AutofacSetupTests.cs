using System.Reflection;
using Autofac;
using NUnit.Framework;
using RestApi.Controllers;
using RestApi.IoC;
using RestApi.Models;
using RestApi.Repository;

namespace RestApiUnitTests.IoC
{
    [TestFixture]
    public class AutofacSetupTests
    {
        [Test]
        public void ResolveController_UsingSqlData_ExpectPatientsControllerAndSqlRepository()
        {
            // arrange
            var ioc = new AutofacSetup();

            var expectedController = typeof (PatientsController);
            var expectedRepository = typeof(PatientRepository);
            var expectedContext = typeof(PatientContext);

            // act
            var container = ioc.Init();

            var actualController = container.Resolve<PatientsController>();
            var actualRepository = container.Resolve<IPatientRepository>();
            var actualContext = container.Resolve<IPatientContext>();

            // assert
            Assert.IsInstanceOf(expectedController, actualController);
            Assert.IsInstanceOf(expectedRepository, actualRepository);
            Assert.IsInstanceOf(expectedContext, actualContext);
        }

        [Test]
        public void ResolveController_UsingImMemoryData_ExpectPatientsControllerAndInMemoryRepository()
        {
            // arrange
            var ioc = new AutofacSetup();

            var expectedController = typeof(PatientsController);
            var expectedRepository = typeof(InMemoryRepository);

            // act
            var container = ioc.Init(true);

            var actualController = container.Resolve<PatientsController>();
            var actualRepository = container.Resolve<IPatientRepository>();

            // assert
            Assert.IsInstanceOf(expectedController, actualController);
            Assert.IsInstanceOf(expectedRepository, actualRepository);
        }
    }
}