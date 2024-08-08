using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MaestusHospital.Data;
using MaestusHospital.Models;
using Microsoft.EntityFrameworkCore;

namespace MaestusHospital.Pages.Patients
{
    public class DetailsModel : PageModel
    {
        private readonly HospitalDbContext _context;

        public DetailsModel(HospitalDbContext context)
        {
            _context = context;
        }

        public Patient Patient { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Patient = await _context.Patients.FirstOrDefaultAsync(m => m.Id == id);

            if (Patient == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
