using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatbot.Models
{
    public class TravelHelp
    {
        public Vehicle Vehicle { get; set; }
        public Path Path { get; set; }
        public List<Stop> Stops { get; set; }
        public Travel Travel { get; set; }
        public List<Reservation> Reservations { get; set; }

        public TravelHelp() {
            /*Travel.Reservations = null;
            Path.Stops = null;
            Vehicle.Path.Stops = null;
            var res = new List<Reservation>();
            foreach (var item in Reservations)
            {
                item.Travel.Reservations = null;
                item.Travel.Transport.Path.Stops = null;
                res.Add(item);
                
            }
            */
        }
        public TravelHelp(Vehicle Vehicle, Path Path, 
            List<Stop> Stops, Travel Travel, List<Reservation> Reservations)
        {
            this.Vehicle = Vehicle;
            this.Path = Path;
            this.Stops = Stops;
            this.Travel = Travel;
            this.Reservations = Reservations;
        }
    }

    
}