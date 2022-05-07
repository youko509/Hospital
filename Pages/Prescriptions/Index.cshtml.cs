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

namespace hosApp.Pages.Prescriptions
{
    public class IndexModel : PageModel
    {
        private readonly hospital _context;

        public IndexModel(hospital context)
        {
            _context = context;
        }

        public IList<Prescription> Prescription { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList FirstName { get; set; }
        [BindProperty(SupportsGet = true)]
        public string PatientName { get; set; }
        public async Task OnGetAsync()
        {
            var prescriptions = from m in _context.Prescription
                                select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                prescriptions = prescriptions.Where(s => s.Consultation.Case.Patient.FirstName.Contains(SearchString));
            }
            Prescription = await prescriptions.Include(p => p.Consultation).ToListAsync();

        }
    }
}
