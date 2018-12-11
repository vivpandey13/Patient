using DBClasses;
using Patient_Demographics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public interface IPatientDemoHelper
    {
        Patient GetPatient(int id);
        void SavePatient(Patient patient);
        List<Patient> GetPatients();

    }
    public class PatientDemoHelper: IPatientDemoHelper
    {
        IPatientDemo_DAO _DAO ;
        public PatientDemoHelper()
        {

        }
        public PatientDemoHelper(IPatientDemo_DAO dao)
        {
            _DAO = dao;
        }
        public Patient GetPatient(int id)
        {
            Patient patient = new Patient();
            patient = _DAO.GetPatient(id);
            return patient;
        }

        public List<Patient> GetPatients()
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
