using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Chatbot.Models
{
    public class Travel
    {
        public int Id { get; set; }
        public ICollection<Reservation> Reservations { get; set; }

        public int TransportId { get; set; }
        public Vehicle Transport { get; set; }

        [NotMapped]
        public int ParticipantCount { get; set; }

        public int PathId { get; set; }
        public virtual Path Path { get; set; }

        public DateTime TravelDate { get; set; }
    }
}