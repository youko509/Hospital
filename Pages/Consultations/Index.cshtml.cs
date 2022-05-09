#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using hosApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace hosApp.Pages.Consultations
{
    public class IndexModel : PageModel
    {
        private readonly hospital _context;

        public IndexModel(hospital context)
        {
            _context = context;
        }

        public IList<Consultation> Consultation { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList FirstName { get; set; }
        [BindProperty(SupportsGet = true)]
        public string DoctorName { get; set; }
        public IList<Doctor> Doctor { get; set; }
        public async Task OnGetAsync()
        {
            var consultations = from m in _context.Consultation
                                select m;
            var doctors = from m in _context.Doctor
                          select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                Doctor doctor = new Doctor();
                Console.Write(SearchString);
                try
                {
                    doctor.ID = doctors.First(s => s.FirstName.Contains(SearchString)).ID;
                }
                catch (InvalidOperationException)
                {

                }
                consultations = consultations.Where(s => s.IdDoctor == doctor.ID);
                doctors = doctors.Where(s => s.FirstName.Contains(SearchString));

            }
            Doctor = await doctors.ToListAsync();
            Consultation = await consultations.Include(c => c.Case).ToListAsync();
        }
    }
}
