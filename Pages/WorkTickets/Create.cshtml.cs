using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Final_Project.Models;

namespace Final_Project.Pages.WorkTickets
{
    public class CreateModel : PageModel
    {
        private readonly Final_Project.Models.TechnicianDbContext _context;

        public CreateModel(Final_Project.Models.TechnicianDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TechnicianId"] = new SelectList(_context.Technician, "TechnicianId", "TechnicianId");
            return Page();
        }

        [BindProperty]
        public WorkTicket WorkTicket { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.WorkTicket.Add(WorkTicket);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
