#nullable disable
namespace hosApp.Models
{
    public class Consultation
    {
        public int ID { get; set; }
        public int IdDoctor { get; set; }
        public Doctor doctor { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public string diagnostic { get; set; }
        public DateTime Date { get; set; }

        public int idCase { get; set; }
        public Case Case { get; set; }
        public Prescription Prescription { get; set; }
    }
}