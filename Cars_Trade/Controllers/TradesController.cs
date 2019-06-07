using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cars_Trade.Models;

namespace Cars_Trade.Controllers
{
    public class TradesController : Controller
    {
        private AutoEntities db = new AutoEntities();

        // GET: Trades
        public ActionResult Index()
        {
            var trades = db.Trades.Include(t => t.Cars).Include(t => t.Clients).Include(t => t.ID_статуса_сделки1);
            return View(trades.ToList());
        }

        // GET: Trades/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trades trades = db.Trades.Find(id);
            if (trades == null)
            {
                return HttpNotFound();
            }
            return View(trades);
        }

        // GET: Trades/Create
        public ActionResult Create()
        {
            ViewBag.Госномер = new SelectList(db.Cars, "Госномер", "Модель");
            ViewBag.Номер_и_серия_паспорта = new SelectList(db.Clients, "Номер_и_серия_паспрта", "ФИО");
            ViewBag.ID_статуса_сделки = new SelectList(db.ID_статуса_сделки, "ID_статуса_сделки1", "Статус_сделки");
            return View();
        }

        // POST: Trades/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Номер_сделки,Госномер,Номер_и_серия_паспорта,ID_статуса_сделки,Срок_сделки,Сумма_сделки")] Trades trades)
        {
            if (ModelState.IsValid)
            {
                db.Trades.Add(trades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Госномер = new SelectList(db.Cars, "Госномер", "Модель", trades.Госномер);
            ViewBag.Номер_и_серия_паспорта = new SelectList(db.Clients, "Номер_и_серия_паспрта", "ФИО", trades.Номер_и_серия_паспорта);
            ViewBag.ID_статуса_сделки = new SelectList(db.ID_статуса_сделки, "ID_статуса_сделки1", "Статус_сделки", trades.ID_статуса_сделки);
            return View(trades);
        }

        // GET: Trades/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trades trades = db.Trades.Find(id);
            if (trades == null)
            {
                return HttpNotFound();
            }
            ViewBag.Госномер = new SelectList(db.Cars, "Госномер", "Модель", trades.Госномер);
            ViewBag.Номер_и_серия_паспорта = new SelectList(db.Clients, "Номер_и_серия_паспрта", "ФИО", trades.Номер_и_серия_паспорта);
            ViewBag.ID_статуса_сделки = new SelectList(db.ID_статуса_сделки, "ID_статуса_сделки1", "Статус_сделки", trades.ID_статуса_сделки);
            return View(trades);
        }

        // POST: Trades/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Номер_сделки,Госномер,Номер_и_серия_паспорта,ID_статуса_сделки,Срок_сделки,Сумма_сделки")] Trades trades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Госномер = new SelectList(db.Cars, "Госномер", "Модель", trades.Госномер);
            ViewBag.Номер_и_серия_паспорта = new SelectList(db.Clients, "Номер_и_серия_паспрта", "ФИО", trades.Номер_и_серия_паспорта);
            ViewBag.ID_статуса_сделки = new SelectList(db.ID_статуса_сделки, "ID_статуса_сделки1", "Статус_сделки", trades.ID_статуса_сделки);
            return View(trades);
        }

        // GET: Trades/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trades trades = db.Trades.Find(id);
            if (trades == null)
            {
                return HttpNotFound();
            }
            return View(trades);
        }

        // POST: Trades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Trades trades = db.Trades.Find(id);
            db.Trades.Remove(trades);
            db.SaveChanges();
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
