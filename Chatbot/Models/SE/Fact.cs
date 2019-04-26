using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chatbot.Models.SE
{
    public class Fact
    {
        [Key]
        public int Id { get; set; }
        public string Question { get; set; }
    }
}