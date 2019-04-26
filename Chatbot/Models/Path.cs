using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chatbot.Models
{
    public class Path
    {
        [Key]
        public int Id { get; set; }
        public string  Start { get; set; }
        public string  End { get; set; }
        public double  Distance { get; set; }
        public virtual ICollection<Stop> Stops { get; set; }
    }
}