using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Final_Project.Models;

namespace Final_Project.Pages.WorkTickets
{
    public class EditModel : PageModel
    {
        private readonly Final_Project.Models.TechnicianDbContext _context;

        public EditModel(Final_Project.Models.TechnicianDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WorkTicket WorkTicket { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WorkTicket = await _context.WorkTicket
                .Include(w => w.Technician).FirstOrDefaultAsync(m => m.WorkTicketId == id);

            if (WorkTicket == null)
            {
                return NotFound();
            }
           ViewData["TechnicianId"] = new SelectList(_context.Technician, "TechnicianId", "TechnicianId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(WorkTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkTicketExists(WorkTicket.WorkTicketId))
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

        private bool WorkTicketExists(int id)
        {
            return _context.WorkTicket.Any(e => e.WorkTicketId == id);
        }
    }
}
