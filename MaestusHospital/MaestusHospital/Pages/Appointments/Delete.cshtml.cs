using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MaestusHospital.Data;
using MaestusHospital.Models;
using Microsoft.EntityFrameworkCore;

namespace MaestusHospital.Pages.Appointments
{
    public class DeleteModel : PageModel
    {
        private readonly HospitalDbContext _context;

        public DeleteModel(HospitalDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Appointment Appointment { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Appointment = await _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Appointment == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Appointment = await _context.Appointments.FindAsync(id);

            if (Appointment != null)
            {
                _context.Appointments.Remove(Appointment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}