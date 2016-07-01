
using RestApi.Models;

namespace RestApi.Repository
{
    public interface IPatientRepository
    {
        Patient GetPatient(int patientId);
    }
}
