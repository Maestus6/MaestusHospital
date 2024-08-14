using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MaestusHospital.Data;
using MaestusHospital.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaestusHospital.Pages.Bills
{
    public class CreateModel : PageModel
    {
        private readonly HospitalDbContext _context;

        public CreateModel(HospitalDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bill Bill { get; set; }

        public SelectList Patients { get; set; }

        public IActionResult OnGet()
        {
            Patients = new SelectList(_context.Patients, "Id", "FirstName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bills.Add(Bill);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
