using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chatbot.Models.SE
{
    public class Rule
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Fact> Facts { get; set; }
    }
}