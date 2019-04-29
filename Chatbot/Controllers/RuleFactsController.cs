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
    public class RuleFactsController : Controller
    {
        private ChatbotContext db = new ChatbotContext();

        // GET: RuleFacts
        public async Task<ActionResult> Index()
        {
           

            /*
            foreach (var elt in db.RuleFacts.ToList())
            {
                db.RuleFacts.Remove(elt);
                db.SaveChanges();
            }
            var listRule= db.Rules.ToList();
            var listFact= db.Facts.ToList();
            var p = new List<String>()
            {
                "F26", "F27","F37","F49","FS59","FS60","FS61","FS63","FS65"
            };
            RuleFact p1 = null;
            foreach (var item in p)
            {
                p1 = new RuleFact()
                {
                    RuleId = listRule.FirstOrDefault(f => f.Name == "R1").Id,
                    FactId = listFact.FirstOrDefault(f => f.Name == item).Id
                };
                db.RuleFacts.Add(p1);
                db.SaveChanges();
            }

            var v = new List<String>()
            {
                "F3", "F11","F12","F13","F14","F15","F16","F17","F18","F19","F21","F22",
                "F23","F28","F36","F39","F42","F43","F48"
            };
            for (int i = 94; i < 118; i++)
            {
                v.Add("FS" + i);
            }

            foreach (var item in v)
            {
                p1 = new RuleFact()
                {
                    RuleId = listRule.FirstOrDefault(f => f.Name == "R2").Id,
                    FactId = listFact.FirstOrDefault(f => f.Name == item).Id
                };
                db.RuleFacts.Add(p1);
                db.SaveChanges();
            }


            var e = new List<String>()
            {
                "F5", "F6","F9","F29","F30","F40","F42","F44","F50","F53","F54"
            };
            for (int i = 118; i < 130; i++)
            {
                e.Add("FS" + i);
            }

            foreach (var item in e)
            {
                p1 = new RuleFact()
                {
                    RuleId = listRule.FirstOrDefault(f => f.Name == "R3").Id,
                    FactId = listFact.FirstOrDefault(f => f.Name == item).Id
                };
                db.RuleFacts.Add(p1);
                db.SaveChanges();
            }

            var t = new List<String>()
            {
                "F1", "F2","F6","F10","F46","F52"
            };
            for (int i = 130; i < 155; i++)
            {
                t.Add("FS" + i);
            }

            foreach (var item in t)
            {
                p1 = new RuleFact()
                {
                    RuleId = listRule.FirstOrDefault(f => f.Name == "R4").Id,
                    FactId = listFact.FirstOrDefault(f => f.Name == item).Id
                };
                db.RuleFacts.Add(p1);
                db.SaveChanges();
            }

            var vo = new List<String>()
            {
                "F4", "F24","F25","F26","F35","F37","F38","F46","FS55","FS56","FS57","FS58",
            };
            for (int i = 79; i < 85; i++)
            {
                vo.Add("FS" + i);
            }

            foreach (var item in vo)
            {
                p1 = new RuleFact()
                {
                    RuleId = listRule.FirstOrDefault(f => f.Name == "R5").Id,
                    FactId = listFact.FirstOrDefault(f => f.Name == item).Id
                };
                db.RuleFacts.Add(p1);
                db.SaveChanges();
            }


            var st = new List<String>()
            {
                "F7"
            };
            for (int i = 73; i < 79; i++)
            {
                st.Add("FS" + i);
            }

            foreach (var item in st)
            {
                  p1 = new RuleFact()
                {
                    RuleId = listRule.FirstOrDefault(f => f.Name == "R6").Id,
                    FactId = listFact.FirstOrDefault(f => f.Name == item).Id
                };
                db.RuleFacts.Add(p1);
                db.SaveChanges();
            }

            var re = new List<String>()
            {
                "F4", "F8","F32","F33","F156","F37","F41", "F50","F51"
            };
            for (int i = 64; i < 73; i++)
            {
                re.Add("FS" + i);
            }

            foreach (var item in re)
            {
                 p1 = new RuleFact()
                {
                    RuleId = listRule.FirstOrDefault(f => f.Name == "R7").Id,
                    FactId = listFact.FirstOrDefault(f => f.Name == item).Id
                };
                db.RuleFacts.Add(p1);
                db.SaveChanges();
            }


            var stv = new List<String>()
            {
                "F31"
            };

            foreach (var item in stv)
            {
                 p1 = new RuleFact()
                {
                    RuleId = listRule.FirstOrDefault(f => f.Name == "R8").Id,
                    FactId = listFact.FirstOrDefault(f => f.Name == item).Id
                };
                db.RuleFacts.Add(p1);
                db.SaveChanges();
            }

            var rl = new List<String>()
            {
                "F34"
            };

            for (int i = 85; i < 93; i++)
            {
                rl.Add("FS" + i);
            }

            foreach (var item in rl)
            {
                 p1 = new RuleFact()
                {
                    RuleId = listRule.FirstOrDefault(f => f.Name == "R9").Id,
                    FactId = listFact.FirstOrDefault(f => f.Name == item).Id
                };
                db.RuleFacts.Add(p1);
                db.SaveChanges();
            }

            var hs = new List<String>()
            {
                "F47"
            };

            foreach (var item in hs)
            {
                 p1 = new RuleFact()
                {
                    RuleId = listRule.FirstOrDefault(f => f.Name == "R10").Id,
                    FactId = listFact.FirstOrDefault(f => f.Name == item).Id
                };
                db.RuleFacts.Add(p1);
                db.SaveChanges();
            }
            */
            var ruleFacts = db.RuleFacts.Include(r => r.Fact).Include(r => r.Rule);
            return View(await ruleFacts.ToListAsync());
        }

        

        // GET: RuleFacts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RuleFact ruleFact = await db.RuleFacts.FindAsync(id);
            if (ruleFact == null)
            {
                return HttpNotFound();
            }
            return View(ruleFact);
        }

        // GET: RuleFacts/Create
        public ActionResult Create()
        {
            ViewBag.FactId = new SelectList(db.Facts, "Id", "Name");
            ViewBag.RuleId = new SelectList(db.Rules, "Id", "Name");
            return View();
        }

        // POST: RuleFacts/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FactId,RuleId")] RuleFact ruleFact)
        {
            if (ModelState.IsValid)
            {
                db.RuleFacts.Add(ruleFact);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FactId = new SelectList(db.Facts, "Id", "Name", ruleFact.FactId);
            ViewBag.RuleId = new SelectList(db.Rules, "Id", "Name", ruleFact.RuleId);
            return View(ruleFact);
        }

        // GET: RuleFacts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RuleFact ruleFact = await db.RuleFacts.FindAsync(id);
            if (ruleFact == null)
            {
                return HttpNotFound();
            }
            ViewBag.FactId = new SelectList(db.Facts, "Id", "Name", ruleFact.FactId);
            ViewBag.RuleId = new SelectList(db.Rules, "Id", "Name", ruleFact.RuleId);
            return View(ruleFact);
        }

        // POST: RuleFacts/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FactId,RuleId")] RuleFact ruleFact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ruleFact).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FactId = new SelectList(db.Facts, "Id", "Name", ruleFact.FactId);
            ViewBag.RuleId = new SelectList(db.Rules, "Id", "Name", ruleFact.RuleId);
            return View(ruleFact);
        }

        // GET: RuleFacts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RuleFact ruleFact = await db.RuleFacts.FindAsync(id);
            if (ruleFact == null)
            {
                return HttpNotFound();
            }
            return View(ruleFact);
        }

        // POST: RuleFacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RuleFact ruleFact = await db.RuleFacts.FindAsync(id);
            db.RuleFacts.Remove(ruleFact);
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
