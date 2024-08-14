using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MaestusHospital.Data;
using MaestusHospital.Models;

namespace MaestusHospital.Pages.Bills
{
    public class DetailsModel : PageModel
    {
        private readonly HospitalDbContext _context;

        public DetailsModel(HospitalDbContext context)
        {
            _context = context;
        }

        public Bill Bill { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Bill = await _context.Bills
                .Include(b => b.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Bill == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
