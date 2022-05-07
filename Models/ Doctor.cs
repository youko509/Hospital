#nullable disable
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace hosApp.Models
{
    public class Doctor
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Tel { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Speciality { get; set; }
        public ICollection<Consultation> consultations { get; set; }
    }
}