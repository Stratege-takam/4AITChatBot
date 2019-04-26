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
    public class HistoryStandardsController : Controller
    {
        private ChatbotContext db = new ChatbotContext();

        // GET: HistoryStandards
        public async Task<ActionResult> Index()
        {
            var historyStandards = db.HistoryStandards.Include(h => h.Standard);
            return View(await historyStandards.ToListAsync());
        }

        // GET: HistoryStandards/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryStandard historyStandard = await db.HistoryStandards.FindAsync(id);
            if (historyStandard == null)
            {
                return HttpNotFound();
            }
            return View(historyStandard);
        }

        // GET: HistoryStandards/Create
        public ActionResult Create()
        {
            ViewBag.StandardId = new SelectList(db.Standards, "Id", "Name");
            return View();
        }

        // POST: HistoryStandards/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PlaceCount,TansportId,StandardId")] HistoryStandard historyStandard)
        {
            if (ModelState.IsValid)
            {
                db.HistoryStandards.Add(historyStandard);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.StandardId = new SelectList(db.Standards, "Id", "Name", historyStandard.StandardId);
            return View(historyStandard);
        }

        // GET: HistoryStandards/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryStandard historyStandard = await db.HistoryStandards.FindAsync(id);
            if (historyStandard == null)
            {
                return HttpNotFound();
            }
            ViewBag.StandardId = new SelectList(db.Standards, "Id", "Name", historyStandard.StandardId);
            return View(historyStandard);
        }

        // POST: HistoryStandards/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PlaceCount,TansportId,StandardId")] HistoryStandard historyStandard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historyStandard).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.StandardId = new SelectList(db.Standards, "Id", "Name", historyStandard.StandardId);
            return View(historyStandard);
        }

        // GET: HistoryStandards/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoryStandard historyStandard = await db.HistoryStandards.FindAsync(id);
            if (historyStandard == null)
            {
                return HttpNotFound();
            }
            return View(historyStandard);
        }

        // POST: HistoryStandards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HistoryStandard historyStandard = await db.HistoryStandards.FindAsync(id);
            db.HistoryStandards.Remove(historyStandard);
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
