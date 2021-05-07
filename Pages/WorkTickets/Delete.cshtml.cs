using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Final_Project.Models;

namespace Final_Project.Pages.WorkTickets
{
    public class DeleteModel : PageModel
    {
        private readonly Final_Project.Models.TechnicianDbContext _context;

        public DeleteModel(Final_Project.Models.TechnicianDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WorkTicket = await _context.WorkTicket.FindAsync(id);

            if (WorkTicket != null)
            {
                _context.WorkTicket.Remove(WorkTicket);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
