using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatbot.Models.SE
{
    public class RuleFact
    {
        public int Id { get; set; }
        public int FactId { get; set; }
        public int RuleId { get; set; }
        public virtual Fact Fact { get; set; }
        public virtual Rule Rule { get; set; }
    }
}