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

namespace hosApp.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private readonly hospital _context;

        public IndexModel(hospital context)
        {
            _context = context;
        }

        public IList<Patient> Patient { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList FirstName { get; set; }
        [BindProperty(SupportsGet = true)]
        public string PatientName { get; set; }
        public async Task OnGetAsync()
        {
            var patients = from m in _context.Patient
                           select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                patients = patients.Where(s => s.FirstName.Contains(SearchString));
            }

            Patient = await patients.ToListAsync();
        }
    }
}
