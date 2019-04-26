namespace Chatbot
{
    using Chatbot.Models;
    using Chatbot.Models.SE;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ChatbotContext : DbContext
    {
        public ChatbotContext()
            : base("name=DefaultConnection")
        {
        }
         public virtual DbSet<Vehicle> Vehicles { get; set; }
         public virtual DbSet<Travel> Travels { get; set; }
         public virtual DbSet<Standard> Standards { get; set; }
         public virtual DbSet<Stop> Stops { get; set; }
         public virtual DbSet<Role> Roles { get; set; }
         public virtual DbSet<Reservation> Reservations { get; set; }
         public virtual DbSet<Path> Paths { get; set; }
         public virtual DbSet<Participant> Participants { get; set; }
         public virtual DbSet<HistoryStandard> HistoryStandards { get; set; }
         public virtual DbSet<Fact> Facts { get; set; }
         public virtual DbSet<Rule> Rules { get; set; }
    }
    
}