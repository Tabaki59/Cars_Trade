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
    public class ClientsController : Controller
    {
        private AutoEntities db = new AutoEntities();

        // GET: Clients
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clients clients = db.Clients.Find(id);
            if (clients == null)
            {
                return HttpNotFound();
            }
            return View(clients);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Номер_и_серия_паспрта,ФИО,Номер_телефона")] Clients clients,string id, [Bind(Include = "Номер_сделки,Госномер,Номер_и_серия_паспорта,ID_статуса_сделки,Срок_сделки,Сумма_сделки")] Trades trades)
        {
            if (ModelState.IsValid)
            {
                if (Choose.choose == 1)
                {
                    Cars cars = db.Cars.Find(id);
                    cars.ID_состояния_авто = 2; //Забронировано
                    trades.ID_статуса_сделки = 2; //На рассмотрении
                    trades.Госномер = id;
                    trades.Срок_сделки = 7;
                    trades.Сумма_сделки = cars.Цена_за_сутки * 7;
                    trades.Номер_и_серия_паспорта = clients.Номер_и_серия_паспрта;
                    int n = 0;
                    if (db.Trades!=null)
                    n = db.Trades.Max(t => t.Номер_сделки);
                    trades.Номер_сделки = Convert.ToByte(n+1);//Создание ключа сделки
                    db.Trades.Add(trades);
                    db.Clients.Add(clients);
                    db.SaveChanges();
                    return View("Keys");
                }
                if (Choose.choose == 2)
                {
                    Cars cars = db.Cars.Find(id);
                    cars.ID_состояния_авто = 3; //На руках
                    trades.ID_статуса_сделки = 1; //Открыта
                    trades.Госномер = id;
                    trades.Срок_сделки = 7;
                    trades.Сумма_сделки = cars.Цена_за_сутки * 7;
                    trades.Номер_и_серия_паспорта = clients.Номер_и_серия_паспрта;
                    int n = 0;
                    if (db.Trades != null)
                        n = db.Trades.Max(t => t.Номер_сделки);
                    trades.Номер_сделки = Convert.ToByte(n + 1);//Создание ключа сделки
                    db.Trades.Add(trades);
                    db.Clients.Add(clients);
                    db.SaveChanges();
                    return RedirectToAction("Index_Employee","Cars");
                }
            }
            return View();
        }


        // GET: Clients/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clients clients = db.Clients.Find(id);
            if (clients == null)
            {
                return HttpNotFound();
            }
            return View(clients);
        }

        // POST: Clients/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Номер_и_серия_паспрта,ФИО,Номер_телефона")] Clients clients)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clients).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clients);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clients clients = db.Clients.Find(id);
            if (clients == null)
            {
                return HttpNotFound();
            }
            return View(clients);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Clients clients = db.Clients.Find(id);
            db.Clients.Remove(clients);
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
