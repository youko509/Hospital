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
            ViewData["PatientRef"] = new SelectList(_context.Patient, "ID", "FirstName");


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
            try
            {
                var random = new Random();
                var list = new List<string>{ "0","A","1","B","2","C","D","H","3","I","J","4","K","5","L","6",
                    "M","N","7","O","8","P","Q","9","R","S","T","U","V","W","X","Y","Z"};
                int index;
                int i = 0;
                string t = "";
                while (i <= 7)
                {
                    index = random.Next(list.Count);
                    t = t + list[index];
                    i++;
                }
                Case.Code = t;
                Case.Date = DateTime.Now;
                _context.Case.Add(Case);
                await _context.SaveChangesAsync();
            }
            catch
            {

            }
            return RedirectToPage("./Index");
        }
    }
}
