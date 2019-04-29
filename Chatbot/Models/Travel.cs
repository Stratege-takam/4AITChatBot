using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Chatbot.Models
{
    public class Travel
    {
        [Key]
        public int Id { get; set; }
        public int TransportId { get; set; }
        public virtual Vehicle Transport { get; set; }
        [NotMapped]
        public int ParticipantCount { get; set; }
        public DateTime TravelStart { get; set; }
        public DateTime TravelEnd { get; set; }
        //public virtual ICollection<Reservation> Reservations { get; set; }
    }
}