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
            var stops = db.Stops.Include(s => s.Path).Include(s => s.Vehicle);
            return View(await stops.ToListAsync());
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
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Type");
            return View();
        }

        // POST: Stops/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,VehicleId,PathId,Cost,StartTime,EndTime")] Stop stop)
        {
            if (ModelState.IsValid)
            {
                db.Stops.Add(stop);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PathId = new SelectList(db.Paths, "Id", "Start", stop.PathId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Type", stop.VehicleId);
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
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Type", stop.VehicleId);
            return View(stop);
        }

        // POST: Stops/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,VehicleId,PathId,Cost,StartTime,EndTime")] Stop stop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stop).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PathId = new SelectList(db.Paths, "Id", "Start", stop.PathId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Type", stop.VehicleId);
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
