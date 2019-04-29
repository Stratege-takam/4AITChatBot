using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatbot.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string CompanyName { get; set; }
        public int PathId { get; set; }
        public virtual Path Path { get; set; }

    } 
}