using Patient_Demographics.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public  class PatientInit 
    {
        

        public static List<Patient> InitializePatient()
        {
            List<Patient> patients = new List<Patient>();
            Patient patient = new Patient();
            patient.ForeName = "John";
            patient.SurName = "Mcgrath";
            patient.Gender = EnumGender.Male;
            patient.DateOfBirth = "01-01-1987";
            Contact contact = new Contact() { ContactType = EnumContact.Home, Number = "1234567890" };
            patient.Contacts = new List<Contact>() { contact };

            patients.Add(patient);
            patient = new Patient();
            patient.ForeName = "Brett";
            patient.SurName = "Kelly";
            patient.Gender = EnumGender.Male;
            patient.DateOfBirth = "01-12-2001";
            contact = new Contact() { ContactType = EnumContact.Mobile, Number = "9879879887" };
            patient.Contacts = new List<Contact>() { contact };
            patients.Add(patient);
            return patients;


        }
    }
}
