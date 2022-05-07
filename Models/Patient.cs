#nullable disable
namespace hosApp.Models
{
    public class Patient
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Tel { get; set; }
        public string Adress { get; set; }
        public Case Case { get; set; }
    }
}