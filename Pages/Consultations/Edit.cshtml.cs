#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hosApp.Models;

namespace hosApp.Pages.Consultations
{
    public class EditModel : PageModel
    {
        private readonly hospital _context;

        public EditModel(hospital context)
        {
            _context = context;
        }

        [BindProperty]
        public Consultation Consultation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Consultation = await _context.Consultation
                .Include(c => c.Case).FirstOrDefaultAsync(m => m.ID == id);

            if (Consultation == null)
            {
                return NotFound();
            }
           ViewData["idCase"] = new SelectList(_context.Case, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Consultation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultationExists(Consultation.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ConsultationExists(int id)
        {
            return _context.Consultation.Any(e => e.ID == id);
        }
    }
}
