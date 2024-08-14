using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MaestusHospital.Data;
using MaestusHospital.Models;
using Microsoft.EntityFrameworkCore;

namespace MaestusHospital.Pages.Bills
{
    public class DeleteModel : PageModel
    {
        private readonly HospitalDbContext _context;

        public DeleteModel(HospitalDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Bill = await _context.Bills.FindAsync(id);

            if (Bill != null)
            {
                _context.Bills.Remove(Bill);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
