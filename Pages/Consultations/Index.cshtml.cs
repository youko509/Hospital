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
        public async Task OnGetAsync()

        {
            var consultations = from m in _context.Consultation
                                select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                consultations = consultations.Where(s => s.doctor.FirstName.Contains(SearchString));
            }
            Consultation = await _context.Consultation
                .Include(c => c.Case).ToListAsync();
        }
    }
}
