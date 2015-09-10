using System;
using System.Runtime.Serialization;

namespace TddDemo.DataContracts
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public DateTime? EnrollmentDate { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public DateTime HireDate { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string LastName { get; set; }
    }
}