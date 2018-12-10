using System;
using System.Runtime.Serialization;

namespace Patient_Demographics.Models
{
    [DataContract(Name = "Contact")]
    public class Contact
    {
        [DataMember(Name ="ID")]
        public int ID { get; set; }
        [DataMember(Name = "ContactType")]
        public EnumContact ContactType { get; set; }
        [DataMember(Name = "Number")]
        public string Number { get; set; }
    }
}