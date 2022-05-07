#nullable disable
namespace hosApp.Models
{
    public class Prescription
    {
        public int ID { get; set; }

        public int idConsul { get; set; }
        public Consultation Consultation { get; set; }
        public string prescription { get; set; }
    }
}