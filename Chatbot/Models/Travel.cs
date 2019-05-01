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
        public string Path { get; set; }
        public DateTime Schedule { get; set; }
        public string Stop { get; set; }
        public double Price { get; set; }
        public string TypeOfTravel { get; set; }
        public string Dock { get; set; }
    }
}