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

namespace hosApp.Pages.Prescriptions
{
    public class EditModel : PageModel
    {
        private readonly hospital _context;

        public EditModel(hospital context)
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
           ViewData["idConsul"] = new SelectList(_context.Consultation, "ID", "ID");
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

            _context.Attach(Prescription).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrescriptionExists(Prescription.ID))
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

        private bool PrescriptionExists(int id)
        {
            return _context.Prescription.Any(e => e.ID == id);
        }
    }
}
