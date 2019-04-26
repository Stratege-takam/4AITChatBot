using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatbot.Models
{
    public class HistoryStandard
    {
        public int Id { get; set; }
        public int PlaceCount { get; set; }
        public int TansportId { get; set; }
        public int StandardId { get; set; }
        public Vehicle Transport { get; set; }
        public Standard Standard { get; set; }

    }
}