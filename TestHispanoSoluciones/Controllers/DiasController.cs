using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestHispanoSoluciones.Models;

namespace TestHispanoSoluciones.Controllers
{
    public class DiasController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        // GET: Dias
        public ActionResult Index()
        {
            return View(db.Dias.ToList());
        }

        // GET: Dias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dias dias = db.Dias.Find(id);
            if (dias == null)
            {
                return HttpNotFound();
            }
            return View(dias);
        }

        // GET: Dias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Dias,Dias1")] Dias dias)
        {
            if (ModelState.IsValid)
            {
                db.Dias.Add(dias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dias);
        }

        // GET: Dias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dias dias = db.Dias.Find(id);
            if (dias == null)
            {
                return HttpNotFound();
            }
            return View(dias);
        }

        // POST: Dias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Dias,Dias1")] Dias dias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dias);
        }

        // GET: Dias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dias dias = db.Dias.Find(id);
            if (dias == null)
            {
                return HttpNotFound();
            }
            return View(dias);
        }

        // POST: Dias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dias dias = db.Dias.Find(id);
            db.Dias.Remove(dias);
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
