using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MaestusHospital.Data;
using MaestusHospital.Models;

namespace MaestusHospital.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private readonly HospitalDbContext _context;

        public IndexModel(HospitalDbContext context)
        {
            _context = context;
        }

        public IList<Patient> Patient { get; set; }

        public async Task OnGetAsync()
        {
            Patient = await _context.Patients.ToListAsync();
        }
    }
}
