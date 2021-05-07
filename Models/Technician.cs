using System;
using System.Collections.Generic;

namespace Final_Project.Models
{
    public class Technician
    {
        public int TechnicianId { get; set; } //Primary Key
        public string TechName { get; set; }
        public string TechEmail { get;set; }
        public List<WorkTicket> WorkTickets {get; set;}
    }
}