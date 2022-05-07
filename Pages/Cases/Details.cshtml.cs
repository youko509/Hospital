#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using hosApp.Models;

namespace hosApp.Pages.Cases
{
    public class DetailsModel : PageModel
    {
        private readonly hospital _context;

        public DetailsModel(hospital context)
        {
            _context = context;
        }

        public Case Case { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Case = await _context.Case
                .Include(p => p.Patient).FirstOrDefaultAsync(m => m.ID == id);

            if (Case == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
