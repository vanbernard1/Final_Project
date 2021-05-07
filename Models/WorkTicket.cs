using System;

namespace Final_Project.Models
{
    public class WorkTicket
    {
        public int WorkTicketId {get; set;} //Primary Key
        public DateTime Date {get; set;}
        public string Name {get; set;}
        public int RoomNumber {get; set;}
        public string CampusName {get; set;}
        public string RequestType {get; set;}
        public int TechnicianId {get; set;} //Foreign Key
        public Technician Technician {get; set;}






    }






}