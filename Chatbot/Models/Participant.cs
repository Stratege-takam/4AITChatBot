using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatbot.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TravelDocument { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}