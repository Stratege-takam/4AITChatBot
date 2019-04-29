using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Chatbot;
using Chatbot.Models;

namespace Chatbot.Controllers
{
    public class PathsController : Controller
    {
        private ChatbotContext db = new ChatbotContext();

        // GET: Paths
        public async Task<ActionResult> Index()
        {
            /*
        
            foreach (var item in db.Stops.ToList())
            {
                db.Stops.Remove(item);
                db.SaveChanges();
            }

            foreach (var item in db.Vehicles.ToList())
            {
                db.Vehicles.Remove(item);
                db.SaveChanges();
            }

            foreach (var item in db.Paths.ToList())
            {
                db.Paths.Remove(item);
                db.SaveChanges();
            }



            foreach (var item in db.Travels.ToList())
            {
                db.Travels.Remove(item);
                db.SaveChanges();
            }

            var listdest = new List<List<string>>()
            {
                new List<String>()
                {
                    "LIERS", "MILMORT","HERSTAL","LIEGE-PALAIS","LIEGE-JONFOSSE"
                    // "LIEGE-JONFOSSE","LIEGE-GUILEMINS",
                    //  "SERAING","OUGREE","FLEMALLE-HAUTE",
                },
                new List<String>()
                {
                    "CHARLEROI-SUD", "JAMIOULX","BEIGNEE","HAM-SUR-HEURE","COUR-SUR-HEURE"
                    //"COUR-SUR-HEURE","BERZEE","PRY", "WALCOURT","YVES-GOMEZEE",
                    //"PHILIPPEVILLE","NARIEMBOURG","COUVIN",
                },
                new List<String>()
                {
                    "POPERINGE", "IEPER","COMINES","MENEN","WEVELGEM"
                    //"WEVELGEM","BISSEGEM","COURTRAI", "MOUSCRON","HERSEAUX",
                   // "FROYENNES","TOURNAI",
                },
                new List<String>()
                {
                    "GERAARDSBERGEN", "ACREN","LESSINES","HOURAING","PAPIGNIES"
                   // "PAPIGNIES","REBAIX","ATH", "MAFFLE","MEVERGNIES-ATTRE",
                    //"BRUGELETTE","CAMBRON-CASTEAU","LENS",
                    //"JURBISE","ERBISOEUL","GHLIN","MONS"
                },
                new List<String>()
                {
                    "BRAINE-L’ALLEUD", "WATERLOO","BRUXELLES","FOREST-MIDI", "RUISBROEK"
                   // "RUISBROEK","LOT","BUIZINGEN", "HALLE","LEMBEEK",
                   // "TUBIZE","HENNUYERES","BRAINE-LE-COMTE",
                },
                new List<String>()
                {
                    "LEUVEN", "HEVERLEE","OUD-HEVERLEE","SINT-JORIS-WEERT","PECROT"
                   // "PECROT","FLORIVAL","ARCHENNES", "GASTUCHE","BASSE-WAVRE",
                   // "BIERGES","WAVRE","OTTIGNIES",
                }
            };

            var stops = new List<Stop>();
            foreach (var listdestination in listdest)
            {
                foreach (var item in listdestination)
                {
                    var i = 0;
                    for (int j = listdestination.IndexOf(item) + 1; j < listdestination.Count(); j++)
                    {
                        var item1 = listdestination[j];
                        if (item != item1)
                        {
                            var st = db.Paths.ToList().FirstOrDefault(f => f.End == item1
                                          && f.Start == item);
                            var path = st==null?  new Path()
                            {
                                Distance = (new Random()).Next(10, 200),
                                End = item1,
                                Start = item
                            } : st;
                            stops = new List<Stop>();
                            var time = 15;
                            var timeend = 30;
                            for (int k = i; k < j ; k++)
                            {
                                var p = k + 1;
                                st = db.Paths.ToList().FirstOrDefault(f => f.End == listdestination[p]
                                         && f.Start == listdestination[k]);
                                var pathStop = new Path()
                                {
                                    Distance = (new Random()).Next(10, 200),
                                    End = listdestination[p],
                                    Start = listdestination[k]
                                };
                                var stop = new Stop()
                                {
                                    Path = path,
                                };
                                stop.PathStop = st == null ? pathStop : st;
                                stops.Add(stop);

                                time += 15;
                                timeend += 15;
                                
                            }

                            if (path.Id ==0)
                            {
                                path.Stops = stops;
                                db.Paths.Add(path);
                                db.SaveChanges();
                            }
                            else
                            {
                                foreach (var stop1 in stops)
                                {
                                    db.Stops.Add(stop1);
                                    db.SaveChanges();
                                }
                            }
                           
                            

                        }
                    }
                    i++;

                }
            }

            var paths = db.Paths.ToList();

            var vhs = new List<Vehicle>()
            {
                new Vehicle(){ Type = "avion", CompanyName="Bruxelles Airline", PathId = paths.FirstOrDefault(f=> f.Start=="LEUVEN" && f.End =="PECROT" ).Id },
                new Vehicle(){ Type = "avion", CompanyName="Air France", PathId = paths.FirstOrDefault(f=> f.Start=="GERAARDSBERGEN" && f.End =="PAPIGNIES" ).Id},
                new Vehicle(){ Type = "avion", CompanyName="Emirats", PathId = paths.FirstOrDefault(f=> f.Start=="HEVERLEE" && f.End =="PECROT" ).Id},
                new Vehicle(){ Type = "avion", CompanyName="Kenya Airways", PathId = paths.FirstOrDefault(f=> f.Start=="CHARLEROI-SUD" && f.End =="COUR-SUR-HEURE" ).Id},
                new Vehicle(){ Type = "bus", CompanyName="DeLIJN", PathId = paths.FirstOrDefault(f=> f.Start=="BRAINE-L’ALLEUD" && f.End =="RUISBROEK" ).Id},
                new Vehicle(){ Type = "bus", CompanyName="STIB", PathId = paths.FirstOrDefault(f=> f.Start=="BRAINE-L’ALLEUD" && f.End =="RUISBROEK" ).Id},
                new Vehicle(){ Type = "bus", CompanyName="TEC", PathId = paths.FirstOrDefault(f=> f.Start=="GERAARDSBERGEN" && f.End =="PAPIGNIES" ).Id},
                new Vehicle(){ Type = "bus", CompanyName="SEAT", PathId = paths.FirstOrDefault(f=> f.Start=="CHARLEROI-SUD" && f.End =="COUR-SUR-HEURE" ).Id},
                new Vehicle(){ Type = "bâteau", CompanyName="SEABOURN", PathId = paths.FirstOrDefault(f=> f.Start=="LEUVEN" && f.End =="PECROT" ).Id},
                new Vehicle(){ Type = "bâteau", CompanyName="PONANT", PathId = paths.FirstOrDefault(f=> f.Start=="BRAINE-L’ALLEUD" && f.End =="RUISBROEK" ).Id},
                new Vehicle(){ Type = "bâteau", CompanyName="OCEANIA CRUISES", PathId = paths.FirstOrDefault(f=> f.Start=="LIERS" && f.End =="LIEGE-JONFOSSE" ).Id},
                new Vehicle(){ Type = "bâteau", CompanyName="CUNARD LINE", PathId = paths.FirstOrDefault(f=> f.Start=="CHARLEROI-SUD" && f.End =="COUR-SUR-HEURE" ).Id},
                new Vehicle(){ Type = "train", CompanyName="STIB", PathId = paths.FirstOrDefault(f=> f.Start=="LEUVEN" && f.End =="PECROT" ).Id},
                new Vehicle(){ Type = "train", CompanyName="SEAT", PathId = paths.FirstOrDefault(f=> f.Start=="BRAINE-L’ALLEUD" && f.End =="RUISBROEK" ).Id},
                new Vehicle(){ Type = "train", CompanyName="SNCB", PathId = paths.FirstOrDefault(f=> f.Start=="GERAARDSBERGEN" && f.End =="PAPIGNIES" ).Id},
                new Vehicle(){ Type = "train", CompanyName="DELIJN", PathId = paths.FirstOrDefault(f=> f.Start=="CHARLEROI-SUD" && f.End =="COUR-SUR-HEURE" ).Id},
                new Vehicle(){ Type = "tram", CompanyName="TEC", PathId = paths.FirstOrDefault(f=> f.Start=="LEUVEN" && f.End =="PECROT" ).Id},
                new Vehicle(){ Type = "tram", CompanyName="STIB", PathId = paths.FirstOrDefault(f=> f.Start=="BRAINE-L’ALLEUD" && f.End =="RUISBROEK" ).Id},
                new Vehicle(){ Type = "tram", CompanyName="DELIJN", PathId = paths.FirstOrDefault(f=> f.Start=="GERAARDSBERGEN" && f.End =="PAPIGNIES" ).Id},
                new Vehicle(){ Type = "tram", CompanyName="SEAT", PathId = paths.FirstOrDefault(f=> f.Start=="POPERINGE" && f.End =="WEVELGEM" ).Id},
            };

            foreach (var item in vhs)
            {
                db.Vehicles.Add(item);
                db.SaveChanges();
            }

            var vehicules = db.Vehicles.ToList();

            var standards = new List<string>()
            {
                "Première classe",
                "Deuxième classe",
                "Classe d'affaire",
                "Classe économique"
            };

            var res = new List<Reservation>();

            var voyage = new Travel();


            var names = new List<string>()
            {
                "Danick",
                "Arno",
                "Yankam",
                "Takam",
                "Ayache",
                "Kinsley",
                "Joseph",
                "Ghislaine",
                "Kamgang",
                "Talla",
                "Sokoudjou",
                "Ndje",
                "Precilia",
                "Leticia",
                "Meleuh",
                "Will",
                "Nell",
                "Ryan",
                "Raina",
                "Talom",
                "Tiogo",
                "Teuffa",
                "Boudge",
                "Obama",
                "Kweni",
                "Kwenti",
                "Yonti",
                "Frid",
                "Larisa",
                "Kevin",
                "Kevine",
                "Madjou",
                "Aurnela",
                "Joel",
                "Hashley",
                "Pierre",
                "Jean",
                "Martine",
                "Hortense",
                "Mami chan",
                "Miriam",
                "Milaine",
                "Carel",
                "Coco",
                "Carine",
                "Bernaud",
                "Gen",
                "Dorena"
            };

            foreach (var item in vehicules)
            {
                var date = DateTime.Now.AddDays((new Random()).Next(2, 30));
                res = new List<Reservation>();

                for (int i = 0; i < (new Random()).Next(8, names.Count); i++)
                {
                    System.Threading.Thread.Sleep(100);
                    var st = standards[(new Random()).Next(0, 4)];
                    var reservation = new Reservation() { Participant = names[i], ReversationDate = date, Standard = st, TravelCost = (new Random()).Next(60, 300) };
                    res.Add(reservation);
                }

                voyage = new Travel()
                {
                    TransportId = item.Id,
                    TravelEnd = date.AddHours((new Random()).Next(3, 6)),
                    TravelStart = date.AddHours((new Random()).Next(1, 3)),
                    Reservations = res
                };
                db.Travels.Add(voyage);
                db.SaveChanges();
            }
            */
            
            return View(await db.Paths.ToListAsync());
        }

        // GET: Paths/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Path path = await db.Paths.FindAsync(id);
            if (path == null)
            {
                return HttpNotFound();
            }
            return View(path);
        }

        // GET: Paths/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paths/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Start,End,Distance")] Path path)
        {
            if (ModelState.IsValid)
            {
                db.Paths.Add(path);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(path);
        }

        // GET: Paths/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Path path = await db.Paths.FindAsync(id);
            if (path == null)
            {
                return HttpNotFound();
            }
            return View(path);
        }

        // POST: Paths/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Start,End,Distance")] Path path)
        {
            if (ModelState.IsValid)
            {
                db.Entry(path).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(path);
        }

        // GET: Paths/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Path path = await db.Paths.FindAsync(id);
            if (path == null)
            {
                return HttpNotFound();
            }
            return View(path);
        }

        // POST: Paths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Path path = await db.Paths.FindAsync(id);
            db.Paths.Remove(path);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
