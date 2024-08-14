using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MaestusHospital.Data;
using MaestusHospital.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaestusHospital.Pages.Appointments
{
    public class CreateModel : PageModel
    {
        private readonly HospitalDbContext _context;

        public CreateModel(HospitalDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Doctors = new SelectList(_context.Doctors, "Id", "FirstName");
            Patients = new SelectList(_context.Patients, "Id", "FirstName");
            return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; }

        public SelectList Doctors { get; set; }
        public SelectList Patients { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Appointments.Add(Appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}