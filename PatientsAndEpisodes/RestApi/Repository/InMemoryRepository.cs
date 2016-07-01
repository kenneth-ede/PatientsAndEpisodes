using System;
using System.Collections.Generic;
using System.Linq;
using RestApi.Models;

namespace RestApi.Repository
{
    public class InMemoryRepository : IPatientRepository
    {
        private List<Patient> patientsInMemory;
        private List<Episode> episodesInMemory;

        public InMemoryRepository()
        {
            patientsInMemory = new List<Patient>
            {
                new Patient
                {
                    DateOfBirth = new DateTime(1972, 10, 27),
                    FirstName = "Millicent",
                    PatientId = 1,
                    LastName = "Hammond",
                    NhsNumber = "1111111111"
                }
            };

             episodesInMemory = new List<Episode>
            {
                new Episode
                {
                    AdmissionDate = new DateTime(2014, 11, 12),
                    Diagnosis = "Irritation of inner ear",
                    DischargeDate = new DateTime(2014, 11, 27),
                    EpisodeId = 1,
                    PatientId = 1
                }
            };

        }

        public Patient GetPatient(int patientId)
        {

            var patientsAndEpisodes =
                from p in patientsInMemory
                join e in episodesInMemory on p.PatientId equals e.PatientId
                where p.PatientId == patientId
                select new {p, e};

            if (patientsAndEpisodes.Any())
            {
                var patient = patientsAndEpisodes.First().p;
                patient.Episodes = patientsAndEpisodes.Select(x => x.e).ToArray();
                return patient;
            }
            
            return null;
        }
    }
}