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
using Chatbot.Models.SE;

namespace Chatbot.Controllers
{
    public class DiagnosticsController : Controller
    {
        private ChatbotContext db = new ChatbotContext();

        // GET: Diagnostics
        public async Task<ActionResult> Index()
        {
            /*
            List<string> l = new List<string>()
            {
                "anesthésie",
                "baguenaude",
                "balade",
                "bonheur",
                "campagne",
                "circuit",
                "croisière",
                "défonce",
                "déplacement",
                "errance",
                "excursion",
                "exode",
                "expédition",
                "exploration",
                "incursion",
                "itinéraire",
                "locomotion",
                "navette",
                "navigation",
                "odyssée",
                "pérégrination",
                "périple",
                "perambulation",
                "promenade",
                "raid",
                "rallye",
                "randonnée",
                "route",
                "séjour",
                "tour",
                "tourisme",
                "tournée",
                "trajet",
                "traversée",
                "trimard",
                "trip",
                "trotte",
                "vadrouille",
                "va-et-vient",
                "virée",
                "allée",
                "venue" ,
                "aller",
                "retour" ,
                "voyag",
                "deplac",
                "balad",
                "Voyage"
            };
            foreach (var item in l)
            {
                var d = new Diagnostic()
                {
                    Subject = "Voyage",
                    Synonym = item
                };
                db.Diagnostics.Add(d);
                db.SaveChanges();
            }


            l = new List<string>()
            {
                "adhérent",
                "affilié",
                "allié",
                "associé",
                "concurrent",
                "conjoint",
                "intervenant",
                "ligué",
                "accidentel",
                "éphémère",
                "épisodique",
                "caduc",
                "campeur",
                "court",
                "estivant",
                "excursionniste",
                "frêle",
                "fragile",
                "frayé",
                "fugace",
                "fugitif",
                "fuyant",
                "fuyard",
                "globe-trotter",
                "incertain",
                "intérimaire",
                "migrateur",
                "momentané",
                "pèlerin",
                "pérégrin",
                "périssable",
                "passagère",
                "passant",
                "peuplé",
                "précaire",
                "représentant",
                "succinct",
                "temporaire",
                "temporel",
                "touriste",
                "transitoire",
                "vacancier",
                "visiteur",
                "voyageur",
                "particip",
                "intervenant",
                "Participant"
            };
            foreach (var item in l)
            {
                var d = new Diagnostic()
                {
                    Subject = "Participant",
                    Synonym = item
                };
                db.Diagnostics.Add(d);
                db.SaveChanges();
            }

            l = new List<string>()
            {
                "accumulation",
                "épargne",
                "approvisionnement",
                "location",
                "provision",
                "réserv",
                "reserv",
                "billet",
                "Réservation"
            };

            foreach (var item in l)
            {
                var d = new Diagnostic()
                {
                    Subject = "Réservation",
                    Synonym = item
                };
                db.Diagnostics.Add(d);
                db.SaveChanges();
            }

            l = new List<string>()
            {
                "étape",
                "cheminement",
                "trajet",
                "chemin",
                "itinéraire",
                "circuit",
                "course",
                "distance",
                "espace",
                "intervalle",
                "itinéraire",
                "marche",
                "mouvement",
                "parcours",
                "route",
                "ruban",
                "tour",
                "tournée",
                "tracé",
                "trajectoire",
                "traversée",
                "trotte",
                "voie",
                "Terminus"
            };

             foreach (var item in l)
            {
                var d = new Diagnostic()
                {
                    Subject = "Trajet",
                    Synonym = item
                };
                db.Diagnostics.Add(d);
                db.SaveChanges();
            }

            l = new List<string>()
             {
                 "escale",
                 "échelle",
                 "arrêt",
                 "étape",
                 "gare",
                 "halte",
                 "pause",
                 "port",
                 "relais"
             };
            foreach (var item in l)
            {
                var d = new Diagnostic()
                {
                    Subject = "Escale",
                    Synonym = item
                };
                db.Diagnostics.Add(d);
                db.SaveChanges();
            }

            l = new List<string>()
            {
                "attelage",
                "automobile",
                "carriole",
                "char",
                "chariot",
                "charrette",
                "fardier",
                "haquet",
                "tombereau",
                "avion",
                "véhicule",
                "tram",
                "bus",
                "avion",
                "bâteau",
                "vol",
                "train"
            };
            foreach (var item in l)
            {
                var d = new Diagnostic()
                {
                    Subject = "Vehicule",
                    Synonym = item
                };
                db.Diagnostics.Add(d);
                db.SaveChanges();
            }

            */
            return View(await db.Diagnostics.ToListAsync());
        }

        // GET: Diagnostics/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnostic diagnostic = await db.Diagnostics.FindAsync(id);
            if (diagnostic == null)
            {
                return HttpNotFound();
            }
            return View(diagnostic);
        }

        // GET: Diagnostics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Diagnostics/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Subject,Synonym")] Diagnostic diagnostic)
        {
            if (ModelState.IsValid)
            {
                db.Diagnostics.Add(diagnostic);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(diagnostic);
        }

        // GET: Diagnostics/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnostic diagnostic = await db.Diagnostics.FindAsync(id);
            if (diagnostic == null)
            {
                return HttpNotFound();
            }
            return View(diagnostic);
        }

        // POST: Diagnostics/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Subject,Synonym")] Diagnostic diagnostic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diagnostic).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(diagnostic);
        }

        // GET: Diagnostics/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnostic diagnostic = await db.Diagnostics.FindAsync(id);
            if (diagnostic == null)
            {
                return HttpNotFound();
            }
            return View(diagnostic);
        }

        // POST: Diagnostics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Diagnostic diagnostic = await db.Diagnostics.FindAsync(id);
            db.Diagnostics.Remove(diagnostic);
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
