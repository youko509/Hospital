#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using hosApp.Models;

namespace hosApp.Pages.Prescriptions
{
    public class CreateModel : PageModel
    {
        private readonly hospital _context;

        public CreateModel(hospital context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["idConsul"] = new SelectList(_context.Consultation, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Prescription Prescription { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Prescription.Add(Prescription);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
