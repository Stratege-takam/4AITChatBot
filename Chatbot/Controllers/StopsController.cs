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
    public class StopsController : Controller
    {
        private ChatbotContext db = new ChatbotContext();

        // GET: Stops
        public async Task<ActionResult> Index()
        {
            /*
            foreach (var item in db.Stops.ToList())
            {
                db.Stops.Remove(item);
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
                    for (int j = listdestination.IndexOf(item)+1; j < listdestination.Count(); j++)
                    {
                        var item1 = listdestination[j];
                        if (item != item1)
                        {
                            var path = new Path()
                            {
                                Distance = (new Random()).Next(10, 200),
                                End = item1,
                                Start = item
                            };
                            stops = new List<Stop>();
                            
                            for (int k = i; k < j + 1; k++)
                            {
                                var time = 15;
                                var timeend = 30;
                                for (int p = k+1; p < j + 1; p++)
                                {


                                    if (listdestination[k] != listdestination[p])
                                    {
                                        var stop = new Stop()
                                        {
                                            Path = path,
                                        };
                                        stops.Add(stop);

                                        time += 15;
                                        timeend += 15;
                                    }
                                }
                            }

                            if (stops.Count > 0)
                            {
                                foreach (var item3 in stops)
                                {
                                    db.Stops.Add(item3);
                                    db.SaveChanges();
                                }
                            }
                            else
                            {
                                db.Paths.Add(path);
                                db.SaveChanges();
                            }

                        }
                    }
                    i++;

                }
            }
            */
            var stoprs = db.Stops; //.Include(s => s.Path);
            return View(await stoprs.ToListAsync());
        }

        // GET: Stops/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stop stop = await db.Stops.FindAsync(id);
            if (stop == null)
            {
                return HttpNotFound();
            }
            return View(stop);
        }

        // GET: Stops/Create
        public ActionResult Create()
        {
            ViewBag.PathId = new SelectList(db.Paths, "Id", "Start");
            return View();
        }

        // POST: Stops/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PathId")] Stop stop)
        {
            if (ModelState.IsValid)
            {
                db.Stops.Add(stop);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PathId = new SelectList(db.Paths, "Id", "Start", stop.PathId);
            return View(stop);
        }

        // GET: Stops/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stop stop = await db.Stops.FindAsync(id);
            if (stop == null)
            {
                return HttpNotFound();
            }
            ViewBag.PathId = new SelectList(db.Paths, "Id", "Start", stop.PathId);
            return View(stop);
        }

        // POST: Stops/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PathId")] Stop stop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stop).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PathId = new SelectList(db.Paths, "Id", "Start", stop.PathId);
            return View(stop);
        }

        // GET: Stops/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stop stop = await db.Stops.FindAsync(id);
            if (stop == null)
            {
                return HttpNotFound();
            }
            return View(stop);
        }

        // POST: Stops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Stop stop = await db.Stops.FindAsync(id);
            db.Stops.Remove(stop);
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
