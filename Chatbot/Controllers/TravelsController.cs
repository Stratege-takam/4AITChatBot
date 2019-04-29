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
    public class TravelsController : Controller
    {
        private ChatbotContext db = new ChatbotContext();

        // GET: Travels
        public async Task<ActionResult> Index()
        {
            var travels = db.Travels; // Include(t => t.Transport);
            return View(await travels.ToListAsync());
        }

        // GET: Travels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel travel = await db.Travels.FindAsync(id);
            if (travel == null)
            {
                return HttpNotFound();
            }
            return View(travel);
        }

        // GET: Travels/Create
        public ActionResult Create()
        {
            ViewBag.TransportId = new SelectList(db.Vehicles, "Id", "Type");
            return View();
        }

        // POST: Travels/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,TransportId,TravelStart,TravelEnd")] Travel travel)
        {
            if (ModelState.IsValid)
            {
                db.Travels.Add(travel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TransportId = new SelectList(db.Vehicles, "Id", "Type", travel.TransportId);
            return View(travel);
        }

        // GET: Travels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel travel = await db.Travels.FindAsync(id);
            if (travel == null)
            {
                return HttpNotFound();
            }
            ViewBag.TransportId = new SelectList(db.Vehicles, "Id", "Type", travel.TransportId);
            return View(travel);
        }

        // POST: Travels/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,TransportId,TravelStart,TravelEnd")] Travel travel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(travel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TransportId = new SelectList(db.Vehicles, "Id", "Type", travel.TransportId);
            return View(travel);
        }

        // GET: Travels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel travel = await db.Travels.FindAsync(id);
            if (travel == null)
            {
                return HttpNotFound();
            }
            return View(travel);
        }

        // POST: Travels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Travel travel = await db.Travels.FindAsync(id);
            db.Travels.Remove(travel);
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
