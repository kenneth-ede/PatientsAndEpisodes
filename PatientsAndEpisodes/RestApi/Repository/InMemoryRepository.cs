using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestApi.Models;

namespace RestApi.Repository
{
    public class InMemoryRepository : IPatientRepository
    {
        public Patient GetPatient(int patientId)
        {
            throw new NotImplementedException();
        }
    }
}