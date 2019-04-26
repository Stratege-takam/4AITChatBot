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
    public class ReservationsController : Controller
    {
        private ChatbotContext db = new ChatbotContext();

        // GET: Reservations
        public async Task<ActionResult> Index()
        {
            var reservations = db.Reservations.Include(r => r.Participant).Include(r => r.Path).Include(r => r.Standard).Include(r => r.Travel);
            return View(await reservations.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = await db.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservations/Create
        public ActionResult Create()
        {
            ViewBag.ParticipantId = new SelectList(db.Participants, "Id", "Name");
            ViewBag.PathId = new SelectList(db.Paths, "Id", "Start");
            ViewBag.StandardId = new SelectList(db.Standards, "Id", "Name");
            ViewBag.TravelId = new SelectList(db.Travels, "Id", "Id");
            return View();
        }

        // POST: Reservations/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ParticipantId,TravelId,StandardId,PathId,ReversationDate,TravelCost,State")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ParticipantId = new SelectList(db.Participants, "Id", "Name", reservation.ParticipantId);
            ViewBag.PathId = new SelectList(db.Paths, "Id", "Start", reservation.PathId);
            ViewBag.StandardId = new SelectList(db.Standards, "Id", "Name", reservation.StandardId);
            ViewBag.TravelId = new SelectList(db.Travels, "Id", "Id", reservation.TravelId);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = await db.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParticipantId = new SelectList(db.Participants, "Id", "Name", reservation.ParticipantId);
            ViewBag.PathId = new SelectList(db.Paths, "Id", "Start", reservation.PathId);
            ViewBag.StandardId = new SelectList(db.Standards, "Id", "Name", reservation.StandardId);
            ViewBag.TravelId = new SelectList(db.Travels, "Id", "Id", reservation.TravelId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ParticipantId,TravelId,StandardId,PathId,ReversationDate,TravelCost,State")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ParticipantId = new SelectList(db.Participants, "Id", "Name", reservation.ParticipantId);
            ViewBag.PathId = new SelectList(db.Paths, "Id", "Start", reservation.PathId);
            ViewBag.StandardId = new SelectList(db.Standards, "Id", "Name", reservation.StandardId);
            ViewBag.TravelId = new SelectList(db.Travels, "Id", "Id", reservation.TravelId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = await db.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Reservation reservation = await db.Reservations.FindAsync(id);
            db.Reservations.Remove(reservation);
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
