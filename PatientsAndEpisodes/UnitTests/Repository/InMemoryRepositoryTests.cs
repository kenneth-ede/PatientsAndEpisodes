using System;
using FluentAssertions;
using NUnit.Framework;
using RestApi.Models;
using RestApi.Repository;

namespace RestApiUnitTests.Repository
{
    [TestFixture]
    public class InMemoryRepositoryTests
    {
        [Test]
        public void GetPatient_PatientDoesNotExist_ExpectNull()
        {
            // arrange
            var patientId = 2;

            var repository = new InMemoryRepository();

            // act
            var patient = repository.GetPatient(patientId);

            // arrange
            patient.Should().BeNull();
        }

        [Test]
        public void GetPatient_PatientExists_ExpectPatient()
        {
            // arrange
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

            var repository = new InMemoryRepository();

            // act
            var patient = repository.GetPatient(patientId);

            // arrange
            patient.ShouldBeEquivalentTo(expected);
        }
    }
}