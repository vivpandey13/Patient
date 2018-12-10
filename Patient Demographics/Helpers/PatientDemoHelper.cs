using DBClasses;
using Patient_Demographics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class PatientDemoHelper
    {
        IPatientDemo_DAO _DAO ;
        public PatientDemoHelper()
        {
            _DAO = new PatientDemo_DAO();
        }
        public Patient GetPatient(int id)
        {
            Patient patient = new Patient();
            patient = _DAO.GetPatient(id);
            return patient;
        }

        public List<Patient> Patients()
        {
            List<Patient> patients = new List<Patient>();
            patients = _DAO.GetPatients();
            return patients;
        }

        public void SavePatient(Patient patient)
        {
            _DAO.SavePatient(patient);
        }
    }
}
