using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Patient_Demographics.Models
{
    [DataContract(Name = "Patient")]
    public class Patient
    {
        [DataMember(Name = "ID")]
        public int ID { get; set; }

        [DataMember(Name ="ForeName")]
        [Display(Name = "Fore Name")]
        [Required]
        public string ForeName { get; set; }

        [DataMember(Name = "SurName")]
        [Display(Name = "Sur Name")]
        [Required]
        public string SurName { get; set; }

        [DataMember(Name = "DateOfBirth")]
        [Display(Name ="Date Of Birth")]
        public string DateOfBirth { get; set; }

        [DataMember(Name = "Gender")]
        [Required]
        public EnumGender Gender { get; set; }

        [DataMember(Name = "Contacts")]
        public List<Contact> Contacts { get; set; }
        public string Data { get; set; }

        public Patient()
        {

        }

        public Patient(int pID,string fName, string sName, string dob,EnumGender gender, List<Contact> contacts)
        {
            this.ID = pID;
            this.ForeName = fName;
            this.SurName = sName;
            this.DateOfBirth = dob;
            this.Gender = gender;
            this.Contacts = contacts;
            
        }
    }
}