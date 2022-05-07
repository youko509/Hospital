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
namespace hosApp.Pages.Doctors
{
    public class IndexModel : PageModel
    {
        private readonly hospital _context;

        public IndexModel(hospital context)
        {
            _context = context;
        }

        public IList<Doctor> Doctor { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Values { get; set; }
        public SelectList FirstName { get; set; }
        [BindProperty(SupportsGet = true)]
        public string DoctorName { get; set; }

        public async Task OnGetAsync()
        {
            var doctors = from m in _context.Doctor
                          select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                doctors = doctors.Where(s => s.FirstName.Contains(SearchString) || s.Speciality.Contains(SearchString));
            }

            Doctor = await doctors.ToListAsync();
        }
    }
}
