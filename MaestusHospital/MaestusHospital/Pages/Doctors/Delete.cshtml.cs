using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MaestusHospital.Data;
using MaestusHospital.Models;
using Microsoft.EntityFrameworkCore;

namespace MaestusHospital.Pages.Doctors
{
    public class DeleteModel : PageModel
    {
        private readonly HospitalDbContext _context;

        public DeleteModel(HospitalDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Doctor Doctor { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Doctor = await _context.Doctors.FirstOrDefaultAsync(m => m.Id == id);

            if (Doctor == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Doctor = await _context.Doctors.FindAsync(id);

            if (Doctor != null)
            {
                _context.Doctors.Remove(Doctor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
