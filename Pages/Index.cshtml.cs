#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using hosApp.Models;
using Microsoft.EntityFrameworkCore;

namespace hosApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    // public IndexModel(hospital context)
    // {
    //     _context = context;
    // }
    // private readonly hospital _context;
    // public IList<Doctor> Doctor { get; set; }
    public void OnGet()
    {
        // var doctors = from m in _context.Doctor
        //               select m;

        // doctors = doctors.Where(s => s.Speciality.Contains("sdf"));

        // Doctor = await doctors.ToListAsync();
    }



}
