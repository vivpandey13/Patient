using DBClasses;
using Helpers;
using Patient_Demographics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Patient_Demographics.Controllers
{
    public class ValuesController : ApiController
    {
        IPatientDemoHelper patientDemoHelper;
        IPatientDemo_DAO patientDemo_DAO;
        
        public ValuesController(IPatientDemo_DAO DAO ,IPatientDemoHelper helper)
        {
            patientDemo_DAO = DAO;
            patientDemoHelper = helper;
        }
        // GET api/values
        public List<Patient> Get()
        {
            return patientDemoHelper.GetPatients();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]Patient patient)
        {
            
            patientDemoHelper.SavePatient(patient);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
