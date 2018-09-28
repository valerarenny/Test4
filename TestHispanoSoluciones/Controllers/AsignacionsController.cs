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
    public class AsignacionsController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        // GET: Asignacions
        public ActionResult Index()
        {
            var asignacion = db.Asignacion.Include(a => a.Carrera);
            return View(asignacion.ToList());
        }

        // GET: Asignacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignacion asignacion = db.Asignacion.Find(id);
            if (asignacion == null)
            {
                return HttpNotFound();
            }
            return View(asignacion);
        }

        // GET: Asignacions/Create
        public ActionResult Create()
        {
            ViewBag.Id_Carrera = new SelectList(db.Carrera, "Id_Carrera", "Carrera1");
            return View();
        }

        // POST: Asignacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Asignacion,Id_Carrera")] Asignacion asignacion)
        {
            if (ModelState.IsValid)
            {
                db.Asignacion.Add(asignacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Carrera = new SelectList(db.Carrera, "Id_Carrera", "Carrera1", asignacion.Id_Carrera);
            return View(asignacion);
        }

        // GET: Asignacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignacion asignacion = db.Asignacion.Find(id);
            if (asignacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Carrera = new SelectList(db.Carrera, "Id_Carrera", "Carrera1", asignacion.Id_Carrera);
            return View(asignacion);
        }

        // POST: Asignacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Asignacion,Id_Carrera")] Asignacion asignacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Carrera = new SelectList(db.Carrera, "Id_Carrera", "Carrera1", asignacion.Id_Carrera);
            return View(asignacion);
        }

        // GET: Asignacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asignacion asignacion = db.Asignacion.Find(id);
            if (asignacion == null)
            {
                return HttpNotFound();
            }
            return View(asignacion);
        }

        // POST: Asignacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asignacion asignacion = db.Asignacion.Find(id);
            db.Asignacion.Remove(asignacion);
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
