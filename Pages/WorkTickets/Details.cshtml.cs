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
    public class DetailsModel : PageModel
    {
        private readonly Final_Project.Models.TechnicianDbContext _context;

        public DetailsModel(Final_Project.Models.TechnicianDbContext context)
        {
            _context = context;
        }

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
    }
}
