#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace hosApp.Models
{
    public class Case
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public int PatientRef { get; set; }
        public Patient Patient { get; set; }
        public List<Consultation> Consultations { get; set; }

    }
}