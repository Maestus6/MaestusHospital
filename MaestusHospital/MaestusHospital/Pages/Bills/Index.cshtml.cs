using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MaestusHospital.Data;
using MaestusHospital.Models;

namespace MaestusHospital.Pages.Bills
{
    public class IndexModel : PageModel
    {
        private readonly HospitalDbContext _context;

        public IndexModel(HospitalDbContext context)
        {
            _context = context;
        }

        public IList<Bill> Bill { get; set; }

        public async Task OnGetAsync()
        {
            Bill = await _context.Bills
                .Include(b => b.Patient)
                .ToListAsync();
        }
    }
}
