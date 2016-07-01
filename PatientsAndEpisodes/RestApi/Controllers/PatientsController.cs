using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Web.Http;
using RestApi.Models;
using RestApi.Repository;

namespace RestApi.Controllers
{
    public class PatientsController : ApiController
    {
        private readonly IPatientRepository _patientRepository;

        public PatientsController( IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public Patient Get(int patientId)
        {
            var patient = _patientRepository.GetPatient(patientId);

            if(patient != null)
                return patient;

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

    }
    
}