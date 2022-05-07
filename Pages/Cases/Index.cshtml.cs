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

namespace hosApp.Pages.Cases
{
    public class IndexModel : PageModel
    {
        private readonly hospital _context;

        public IndexModel(hospital context)
        {
            _context = context;
        }

        public IList<Case> Case { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList FirstName { get; set; }
        [BindProperty(SupportsGet = true)]
        public string DoctorName { get; set; }
        public async Task OnGetAsync()
        {
            var cases = from m in _context.Case
                        select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                cases = cases.Where(s => s.Patient.FirstName.Contains(SearchString));
            }
            Case = await _context.Case
                .Include(p => p.Patient).ToListAsync();
        }
    }
}
