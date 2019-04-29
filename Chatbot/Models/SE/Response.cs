using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatbot.Models.SE
{
    public class Response
    {
        public string Search { get; set; }
        public List<string> results { get; set; }
    }
}