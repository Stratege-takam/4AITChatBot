using Chatbot.Models;
using Chatbot.Models.SE;
using Chatbot.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chatbot.Controllers
{
    public class HomeController : Controller
    {
        private ChatbotContext db = new ChatbotContext();
        public ActionResult Index()
        {
            Response response = new Response();
            return View(response);
        }

        [HttpPost]
        public ActionResult Index(Response response)
        {
            response.results = response.Search
                                .WordswithoutPronoun()
                                .AllDomainWorldsInPhrase();
            return View(response);
        }

        public ActionResult Chat()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //var result = Chatbot.Utils.Chatbot.GetTravel();
            List<TravelHelp> travelHelps = new List<TravelHelp>();

            var vehicules = db.Vehicles.ToList();
            var travels = db.Travels.ToList();
            var paths = db.Paths.ToList();
            var stops = db.Stops.ToList();
            var reservations = db.Reservations.ToList();
            foreach (var vehicle in vehicules.ToList())
            {
                var tvels = travels.
                                Where(f => f.TransportId == vehicle.Id).ToList();

                foreach (var travel in tvels)
                {
                    var travelhelp = new TravelHelp()
                    {
                        Travel = travel,
                        Path = vehicle.Path,
                        Vehicle = vehicle,
                        Reservations = reservations.Where(f => f.TravelId == travel.Id).ToList(),
                        Stops = stops.Where(f => f.PathId == vehicle.PathId).ToList()
                    };


                    travelhelp.Travel.ParticipantCount = travelhelp.Reservations.Count();

                    travelhelp.Travel.Transport = null;
                    travelhelp.Vehicle.Path = null;
                    travelhelp.Reservations = travelhelp.
                        Reservations.Select(f=>new Reservation() {
                             Participant = f.Participant,
                              Id = f.Id,
                               ReversationDate = f.ReversationDate,
                                Standard = f.Standard,
                                 Travel = null,
                                  TravelCost = f.TravelCost,
                                  TravelId = f.TravelId
                        }).ToList();
                    /*travelhelp.Stops = travelhelp.Stops.Select(f => new Stop()
                    {
                         Id = f.Id,
                          Path = null,
                           PathId = f.PathId,
                            PathStop = null,
                             PathStopId = f.PathStopId
                    }).ToList();
                    */
                    travelHelps.Add(travelhelp);
                }
            }

            return Json(travelHelps, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}