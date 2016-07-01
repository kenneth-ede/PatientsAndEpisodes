using System.Linq;
using RestApi.Models;

namespace RestApi.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IPatientContext _patientContext;

        public PatientRepository(IPatientContext patientContext)
        {
            _patientContext = patientContext;
        }

        public Patient GetPatient(int patientId)
        {
            var patientsAndEpisodes =
                from p in _patientContext.Patients
                join e in _patientContext.Episodes on p.PatientId equals e.PatientId
                where p.PatientId == patientId
                select new {p, e};

            if (patientsAndEpisodes.Any())
            {
                var first = patientsAndEpisodes.First().p;
                first.Episodes = patientsAndEpisodes.Select(x => x.e).ToArray();
                return first;
            }

            return null;
        }
    }
}