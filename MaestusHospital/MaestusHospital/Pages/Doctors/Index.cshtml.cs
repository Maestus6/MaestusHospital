using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MaestusHospital.Data;
using MaestusHospital.Models;

namespace MaestusHospital.Pages.Doctors
{
    public class IndexModel : PageModel
    {
        private readonly HospitalDbContext _context;

        public IndexModel(HospitalDbContext context)
        {
            _context = context;
        }

        public IList<Doctor> Doctor { get; set; }

        public async Task OnGetAsync()
        {
            Doctor = await _context.Doctors.ToListAsync();
        }
    }
}
