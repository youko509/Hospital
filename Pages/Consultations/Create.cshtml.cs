#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using hosApp.Models;

namespace hosApp.Pages.Consultations
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
            var cases = from m in _context.Case
                        select m;
            var patients = from m in _context.Patient
                           select m;

            ViewData["idCase"] = new SelectList(_context.Case, "ID", "Code");
            ViewData["idDoctor"] = new SelectList(_context.Doctor, "ID", "FirstName");
            return Page();
        }

        [BindProperty]
        public Consultation Consultation { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Consultation.Date = DateTime.Now;
            _context.Consultation.Add(Consultation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
