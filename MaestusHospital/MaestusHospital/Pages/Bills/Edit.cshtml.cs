using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MaestusHospital.Data;
using MaestusHospital.Models;

namespace MaestusHospital.Pages.Bills
{
    public class EditModel : PageModel
    {
        private readonly HospitalDbContext _context;

        public EditModel(HospitalDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bill Bill { get; set; }

        public SelectList Patients { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Bill = await _context.Bills
                .Include(b => b.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Bill == null)
            {
                return NotFound();
            }

            Patients = new SelectList(_context.Patients, "Id", "FirstName", Bill.PatientId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillExists(Bill.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BillExists(int id)
        {
            return _context.Bills.Any(e => e.Id == id);
        }
    }
}