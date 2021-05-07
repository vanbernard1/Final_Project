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
    public class IndexModel : PageModel
    {
        private readonly Final_Project.Models.TechnicianDbContext _context;

        public IndexModel(Final_Project.Models.TechnicianDbContext context)
        {
            _context = context;
        }

        public IList<WorkTicket> WorkTicket { get;set; }

        public async Task OnGetAsync()
        {
            WorkTicket = await _context.WorkTicket
                .Include(w => w.Technician).ToListAsync();
        }
    }
}
