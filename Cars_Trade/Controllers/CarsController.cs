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
    public class CarsController : Controller
    {
        private AutoEntities db = new AutoEntities();

        // GET: Cars
        public ActionResult Index()
        {
            var cars = db.Cars.Include(c => c.ID_класса_автомобиля1).Include(c => c.ID_состояния_авто1).Include(c => c.ID_типа_двигателя1).Include(c => c.ID_типа_коробки1).Include(c => c.ID_типа_кузова1).Include(c => c.ID_типа_привода1).Include(c => c.ID_типа_страховки1).Include(c => c.ID_типа_топлива1);
            return View(cars.ToList());
        }

        // GET: Cars/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            return View(cars);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            ViewBag.ID_класса_автомобиля = new SelectList(db.ID_класса_автомобиля, "ID_класса_автомобиля1", "Класс_автомобиля");
            ViewBag.ID_состояния_авто = new SelectList(db.ID_состояния_авто, "ID_состояния_авто1", "Состояние_авто");
            ViewBag.ID_типа_двигателя = new SelectList(db.ID_типа_двигателя, "ID_типа_двигателя1", "Тип_двигателя");
            ViewBag.ID_типа_коробки = new SelectList(db.ID_типа_коробки, "ID_типа_коробки1", "Тип_коробки");
            ViewBag.ID_типа_кузова = new SelectList(db.ID_типа_кузова, "ID_типа_кузова1", "Тип_кузова");
            ViewBag.ID_типа_привода = new SelectList(db.ID_типа_привода, "ID_типа_привода1", "Тип_привода");
            ViewBag.ID_типа_страховки = new SelectList(db.ID_типа_страховки, "ID_типа_страховки1", "Тип_страховки");
            ViewBag.ID_типа_топлива = new SelectList(db.ID_типа_топлива, "ID_типа_топлива1", "Тип_топлива");
            return View();
        }

        // POST: Cars/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Госномер,Модель,ID_типа_кузова,ID_типа_коробки,ID_типа_привода,Объем_двигателя,Расход_на_100_км,ID_состояния_авто,Год_выпуска,Количество_мест,Вместимость_багажника,ID_типа_топлива,ID_типа_страховки,Цена_за_сутки,ID_типа_двигателя,ID_класса_автомобиля")] Cars cars)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(cars);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_класса_автомобиля = new SelectList(db.ID_класса_автомобиля, "ID_класса_автомобиля1", "Класс_автомобиля", cars.ID_класса_автомобиля);
            ViewBag.ID_состояния_авто = new SelectList(db.ID_состояния_авто, "ID_состояния_авто1", "Состояние_авто", cars.ID_состояния_авто);
            ViewBag.ID_типа_двигателя = new SelectList(db.ID_типа_двигателя, "ID_типа_двигателя1", "Тип_двигателя", cars.ID_типа_двигателя);
            ViewBag.ID_типа_коробки = new SelectList(db.ID_типа_коробки, "ID_типа_коробки1", "Тип_коробки", cars.ID_типа_коробки);
            ViewBag.ID_типа_кузова = new SelectList(db.ID_типа_кузова, "ID_типа_кузова1", "Тип_кузова", cars.ID_типа_кузова);
            ViewBag.ID_типа_привода = new SelectList(db.ID_типа_привода, "ID_типа_привода1", "Тип_привода", cars.ID_типа_привода);
            ViewBag.ID_типа_страховки = new SelectList(db.ID_типа_страховки, "ID_типа_страховки1", "Тип_страховки", cars.ID_типа_страховки);
            ViewBag.ID_типа_топлива = new SelectList(db.ID_типа_топлива, "ID_типа_топлива1", "Тип_топлива", cars.ID_типа_топлива);
            return View(cars);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_класса_автомобиля = new SelectList(db.ID_класса_автомобиля, "ID_класса_автомобиля1", "Класс_автомобиля", cars.ID_класса_автомобиля);
            ViewBag.ID_состояния_авто = new SelectList(db.ID_состояния_авто, "ID_состояния_авто1", "Состояние_авто", cars.ID_состояния_авто);
            ViewBag.ID_типа_двигателя = new SelectList(db.ID_типа_двигателя, "ID_типа_двигателя1", "Тип_двигателя", cars.ID_типа_двигателя);
            ViewBag.ID_типа_коробки = new SelectList(db.ID_типа_коробки, "ID_типа_коробки1", "Тип_коробки", cars.ID_типа_коробки);
            ViewBag.ID_типа_кузова = new SelectList(db.ID_типа_кузова, "ID_типа_кузова1", "Тип_кузова", cars.ID_типа_кузова);
            ViewBag.ID_типа_привода = new SelectList(db.ID_типа_привода, "ID_типа_привода1", "Тип_привода", cars.ID_типа_привода);
            ViewBag.ID_типа_страховки = new SelectList(db.ID_типа_страховки, "ID_типа_страховки1", "Тип_страховки", cars.ID_типа_страховки);
            ViewBag.ID_типа_топлива = new SelectList(db.ID_типа_топлива, "ID_типа_топлива1", "Тип_топлива", cars.ID_типа_топлива);
            return View(cars);
        }

        // POST: Cars/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Госномер,Модель,ID_типа_кузова,ID_типа_коробки,ID_типа_привода,Объем_двигателя,Расход_на_100_км,ID_состояния_авто,Год_выпуска,Количество_мест,Вместимость_багажника,ID_типа_топлива,ID_типа_страховки,Цена_за_сутки,ID_типа_двигателя,ID_класса_автомобиля")] Cars cars)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cars).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_класса_автомобиля = new SelectList(db.ID_класса_автомобиля, "ID_класса_автомобиля1", "Класс_автомобиля", cars.ID_класса_автомобиля);
            ViewBag.ID_состояния_авто = new SelectList(db.ID_состояния_авто, "ID_состояния_авто1", "Состояние_авто", cars.ID_состояния_авто);
            ViewBag.ID_типа_двигателя = new SelectList(db.ID_типа_двигателя, "ID_типа_двигателя1", "Тип_двигателя", cars.ID_типа_двигателя);
            ViewBag.ID_типа_коробки = new SelectList(db.ID_типа_коробки, "ID_типа_коробки1", "Тип_коробки", cars.ID_типа_коробки);
            ViewBag.ID_типа_кузова = new SelectList(db.ID_типа_кузова, "ID_типа_кузова1", "Тип_кузова", cars.ID_типа_кузова);
            ViewBag.ID_типа_привода = new SelectList(db.ID_типа_привода, "ID_типа_привода1", "Тип_привода", cars.ID_типа_привода);
            ViewBag.ID_типа_страховки = new SelectList(db.ID_типа_страховки, "ID_типа_страховки1", "Тип_страховки", cars.ID_типа_страховки);
            ViewBag.ID_типа_топлива = new SelectList(db.ID_типа_топлива, "ID_типа_топлива1", "Тип_топлива", cars.ID_типа_топлива);
            return View(cars);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            return View(cars);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Cars cars = db.Cars.Find(id);
            db.Cars.Remove(cars);
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
