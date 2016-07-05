using System;
using System.Net;
using System.Web.Http;
using Autofac;
using FluentAssertions;
using NUnit.Framework;
using RestApi.Controllers;
using RestApi.IoC;
using RestApi.Models;

namespace RestApiUnitTests.Controllers
{
    [TestFixture]
    public class PatientsControllerTests
    {
        [Test]
        public void Get_PatientExistsWithAnEpisode_ExpectPatientWithEpisode()
        {
            // arrange
            var ioc = new AutofacSetup();

            var useInMemoryDataContext = true;

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            var container = ioc.Init(useInMemoryDataContext);

            var controller = container.Resolve<PatientsController>();

            var patientId = 1;

            var expected = new Patient
            {
                DateOfBirth = new DateTime(1972, 10, 27),
                FirstName = "Millicent",
                PatientId = patientId,
                LastName = "Hammond",
                NhsNumber = "1111111111",
                Episodes = new[]
                {
                    new Episode
                    {
                        AdmissionDate = new DateTime(2014, 11, 12),
                        Diagnosis = "Irritation of inner ear",
                        DischargeDate = new DateTime(2014, 11, 27),
                        EpisodeId = 1,
                        PatientId = patientId
                    }
                }
            };

            // act
            var patient = controller.Get(patientId);

            // assert
            patient.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void Get_PatientDoesNotExist_ThrowsHttpResponseExceptionHttpStatusCodeNotFound()
        {
            // arrange
            var ioc = new AutofacSetup();

            var useInMemoryDataContext = true;

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            var container = ioc.Init(useInMemoryDataContext);

            var controller = container.Resolve<PatientsController>();

            var patientId = 2;

            // act
            Action action = () => controller.Get(patientId);

            // assert
            action.ShouldThrowExactly<HttpResponseException>(HttpStatusCode.NotFound.ToString());
        }
    }
}