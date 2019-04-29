using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatbot.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Participant { get; set; }
        public string Standard { get; set; }
        public int TravelId { get; set; }
        public virtual Travel Travel { get; set; }
        public DateTime ReversationDate { get; set; }
        public Double TravelCost { get; set; }
    }
}