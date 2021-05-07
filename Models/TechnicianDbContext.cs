using Microsoft.EntityFrameworkCore;

namespace Final_Project.Models
{
    public class TechnicianDbContext : DbContext
    {

        public TechnicianDbContext (DbContextOptions<TechnicianDbContext> options)
            : base(options)
        {
        }
    
        public DbSet<Technician> Technician {get; set;}
        public DbSet<WorkTicket> WorkTicket {get; set;}
    }
}