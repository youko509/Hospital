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
        public IList<Case> Case { get; set; }
        public IList<Patient> Patient { get; set; }
        public async Task OnGetAsync()
        {
            var consultations = from m in _context.Consultation
                                select m;
            var doctors = from m in _context.Doctor
                          select m;
            var cases = from m in _context.Case
                        select m;
            var patients = from m in _context.Patient
                           select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                Patient patient = new Patient();
                Doctor doctor = new Doctor();
                Case case1 = new Case();

                try
                {
                    patient.ID = patients.First(s => s.FirstName.Contains(SearchString) || s.LastName.Contains(SearchString)).ID;
                    case1.ID = cases.First(s => s.PatientRef == patient.ID).ID;

                }
                catch { }
                Console.WriteLine(case1.ID);
                consultations = consultations.Where(s => s.idCase == case1.ID);
                // doctors = doctors.Where(s => s.FirstName.Contains(SearchString));
            }
            Doctor = await doctors.ToListAsync();
            Case = await cases.ToListAsync();
            Patient = await patients.ToListAsync();
            Consultation = await consultations.Include(c => c.Case).ToListAsync();
        }
    }
}
