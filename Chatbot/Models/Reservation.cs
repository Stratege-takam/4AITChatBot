using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatbot.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int ParticipantId { get; set; }
        public virtual Participant Participant { get; set; }
        public int TravelId { get; set; }
        public virtual Travel Travel { get; set; }
        public int StandardId { get; set; }
        public Standard Standard { get; set; }
        public int PathId { get; set; }
        public virtual Path Path { get; set; }
        public DateTime ReversationDate { get; set; }
        public Double TravelCost { get; set; }
        public Boolean State { get; set; }
    }
}