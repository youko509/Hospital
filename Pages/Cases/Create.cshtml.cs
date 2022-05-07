#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using hosApp.Models;

namespace hosApp.Pages.Cases
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
            ViewData["PatientRef"] = new SelectList(_context.Patient, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Case Case { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Case.Add(Case);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
