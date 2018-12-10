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
        List<Patient> patients = new List<Patient>();
        public ValuesController()
        {
            //List<Contact> contacts = new List<Contact>();
            //Contact homePhone = new Contact()
            //{
            //    ContactType = EnumContact.Home,
            //    Number = "1234567890"
            //};
            //contacts.Add(homePhone);
            //Patient patient = new Patient(patients.Count+1,"Mike", "Hussy", DateTime.Today.ToShortDateString(), EnumGender.Male, contacts);
            //patients.Add(patient);
        }
        // GET api/values
        public List<Patient> Get()
        {
            PatientDemoHelper helper = new PatientDemoHelper();

            return helper.Patients();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]Patient patient)
        {
            PatientDemoHelper helper = new PatientDemoHelper();
            helper.SavePatient(patient);
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
