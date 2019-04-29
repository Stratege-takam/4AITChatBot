using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chatbot.Models.SE
{
    public class Diagnostic
    {
        [Key]
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Synonym { get; set; }
    }
}