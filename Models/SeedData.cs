using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Collections.Generic;


namespace Final_Project.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TechnicianDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<TechnicianDbContext>>()))
            {
                // Look for any Technicians.
                if (context.Technician.Any())
                {
                    return; // DB has been seeded
                }
                
                context.Technician.AddRange(
                    new Technician
                    {
                        TechName = "Vanessa Bernard",
                        TechEmail = "vbernard@bisd.net"
                        
                    },

                    new Technician

                    {
                        TechName = "DJ Rambo",
                        TechEmail = "drambo@bisd.net"
                    },

                    new Technician
                    {
                        TechName = "Cynthia Ellis",
                        TechEmail = "cellis@bisd.net"
                    },

                    new Technician
                    {
                        TechName = "Mario Carrillo",
                        TechEmail = "mcarrillo@bisd.net"
                    },

                    new Technician
                    {
                        TechName = "Alix Yeargin",
                        TechEmail = "ayeargin@bisd.net"
                    },

                    new Technician
                    {
                        TechName = "Isabel Espinoza",
                        TechEmail = "iespinoza@bisd.net"
                    },

                    new Technician
                    {
                        TechName = "Scott Vincent",
                        TechEmail = "svincent@bisd.net"
                    },

                    new Technician
                    {
                        TechName = "Michael Lloyd",
                        TechEmail = "mlloyd@bisd.net"
                    },

                    new Technician
                    {
                        TechName = "Drew Hayes",
                        TechEmail = "dyahes@bisd.net"
                    },
                    
                    new Technician
                    {
                        TechName = "Mitch Bryant",
                        TechEmail = "mbryant@bisd.net"
                    }
                );
            context.SaveChanges();
            }
        }
    }
}

