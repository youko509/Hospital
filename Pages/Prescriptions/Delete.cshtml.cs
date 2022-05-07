#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using hosApp.Models;

namespace hosApp.Pages.Prescriptions
{
    public class DeleteModel : PageModel
    {
        private readonly hospital _context;

        public DeleteModel(hospital context)
        {
            _context = context;
        }

        [BindProperty]
        public Prescription Prescription { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Prescription = await _context.Prescription
                .Include(p => p.Consultation).FirstOrDefaultAsync(m => m.ID == id);

            if (Prescription == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Prescription = await _context.Prescription.FindAsync(id);

            if (Prescription != null)
            {
                _context.Prescription.Remove(Prescription);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
