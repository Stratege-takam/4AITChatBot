namespace Chatbot
{
    using Chatbot.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ChatbotContext : DbContext
    {
        public ChatbotContext()
            : base("name=DefaultConnection")
        {
        }
         public virtual DbSet<Travel> Travels { get; set; }
         public virtual DbSet<TravelHelp> TravelHelps { get; set; }



    }

}