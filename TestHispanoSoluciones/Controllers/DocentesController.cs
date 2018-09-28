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
    public class DocentesController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        // GET: Docentes
        public ActionResult Index()
        {
            var docente = db.Docente.Include(d => d.Asignacion).Include(d => d.Rol).Include(d => d.Status).Include(d => d.Turno);
            return View(docente.ToList());
        }

        // GET: Docentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docente docente = db.Docente.Find(id);
            if (docente == null)
            {
                return HttpNotFound();
            }
            return View(docente);
        }

        // GET: Docentes/Create
        public ActionResult Create()
        {
            ViewBag.Id_Asignacion = new SelectList(db.Asignacion, "Id_Asignacion", "Id_Asignacion");
            ViewBag.Id_Rol = new SelectList(db.Rol, "Id_Rol", "Rol1");
            ViewBag.Id_Status = new SelectList(db.Status, "Id_Status", "Status1");
            ViewBag.Id_Turno = new SelectList(db.Turno, "Id_Turno", "Id_Turno");
            return View();
        }

        // POST: Docentes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Docente,Nombre,Apellido,DNI,Id_Status,Id_Rol,Id_Turno,Id_Asignacion")] Docente docente)
        {
            if (ModelState.IsValid)
            {
                db.Docente.Add(docente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Asignacion = new SelectList(db.Asignacion, "Id_Asignacion", "Id_Asignacion", docente.Id_Asignacion);
            ViewBag.Id_Rol = new SelectList(db.Rol, "Id_Rol", "Rol1", docente.Id_Rol);
            ViewBag.Id_Status = new SelectList(db.Status, "Id_Status", "Status1", docente.Id_Status);
            ViewBag.Id_Turno = new SelectList(db.Turno, "Id_Turno", "Id_Turno", docente.Id_Turno);
            return View(docente);
        }

        // GET: Docentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docente docente = db.Docente.Find(id);
            if (docente == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Asignacion = new SelectList(db.Asignacion, "Id_Asignacion", "Id_Asignacion", docente.Id_Asignacion);
            ViewBag.Id_Rol = new SelectList(db.Rol, "Id_Rol", "Rol1", docente.Id_Rol);
            ViewBag.Id_Status = new SelectList(db.Status, "Id_Status", "Status1", docente.Id_Status);
            ViewBag.Id_Turno = new SelectList(db.Turno, "Id_Turno", "Id_Turno", docente.Id_Turno);
            return View(docente);
        }

        // POST: Docentes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Docente,Nombre,Apellido,DNI,Id_Status,Id_Rol,Id_Turno,Id_Asignacion")] Docente docente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Asignacion = new SelectList(db.Asignacion, "Id_Asignacion", "Id_Asignacion", docente.Id_Asignacion);
            ViewBag.Id_Rol = new SelectList(db.Rol, "Id_Rol", "Rol1", docente.Id_Rol);
            ViewBag.Id_Status = new SelectList(db.Status, "Id_Status", "Status1", docente.Id_Status);
            ViewBag.Id_Turno = new SelectList(db.Turno, "Id_Turno", "Id_Turno", docente.Id_Turno);
            return View(docente);
        }

        // GET: Docentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docente docente = db.Docente.Find(id);
            if (docente == null)
            {
                return HttpNotFound();
            }
            return View(docente);
        }

        // POST: Docentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Docente docente = db.Docente.Find(id);
            db.Docente.Remove(docente);
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
