using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chatbot.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int ParticipantId { get; set; }
        public virtual Participant Participant { get; set; }
        public int TransportId { get; set; }
        public virtual Vehicle Transport { get; set; }
    }
}