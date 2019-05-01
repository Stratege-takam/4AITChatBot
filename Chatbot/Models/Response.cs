using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chatbot.Models
{
    public class Response
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Search { get; set; }

        public bool BotBegin { get; set; } = false;

        public List<TravelHelp> travelHelps { get; set; } = new List<TravelHelp>();
    }
}