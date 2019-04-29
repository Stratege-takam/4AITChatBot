using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chatbot.Models
{
    public class Stop
    {
        [Key]
        public int Id { get; set; }
        public int PathId { get; set; }
        public virtual Path Path { get; set; }

        public int PathStopId { get; set; }
        public virtual Path PathStop { get; set; }

    }
}