using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MaestusHospital.Data;
using MaestusHospital.Models;

namespace MaestusHospital.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly HospitalDbContext _context;

        public IndexModel(HospitalDbContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get; set; }

        public async Task OnGetAsync()
        {
            Appointment = await _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .ToListAsync();
        }
    }
}
