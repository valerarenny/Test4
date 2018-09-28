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
    public class LaboratoriosController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        // GET: Laboratorios
        public ActionResult Index()
        {
            var laboratorio = db.Laboratorio.Include(l => l.Docente).Include(l => l.PersonalAdministrativo).Include(l => l.Status).Include(l => l.TipoLab);
            return View(laboratorio.ToList());
        }

        // GET: Laboratorios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laboratorio laboratorio = db.Laboratorio.Find(id);
            if (laboratorio == null)
            {
                return HttpNotFound();
            }
            return View(laboratorio);
        }

        // GET: Laboratorios/Create
        public ActionResult Create()
        {
            ViewBag.Id_Asignado = new SelectList(db.Docente, "Id_Docente", "Nombre");
            ViewBag.Id_Encargado = new SelectList(db.PersonalAdministrativo, "Id_PersonalAdm", "Nombres");
            ViewBag.Id_Status = new SelectList(db.Status, "Id_Status", "Status1");
            ViewBag.Id_TipoLab = new SelectList(db.TipoLab, "Id_TipoLab", "Tipo_Lab");
            return View();
        }

        // POST: Laboratorios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Lab,Id_Asignado,Id_Status,Id_Encargado,CapMax,NroEquipos,Id_TipoLab")] Laboratorio laboratorio)
        {
            if (ModelState.IsValid)
            {
                db.Laboratorio.Add(laboratorio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Asignado = new SelectList(db.Docente, "Id_Docente", "Nombre", laboratorio.Id_Asignado);
            ViewBag.Id_Encargado = new SelectList(db.PersonalAdministrativo, "Id_PersonalAdm", "Nombres", laboratorio.Id_Encargado);
            ViewBag.Id_Status = new SelectList(db.Status, "Id_Status", "Status1", laboratorio.Id_Status);
            ViewBag.Id_TipoLab = new SelectList(db.TipoLab, "Id_TipoLab", "Tipo_Lab", laboratorio.Id_TipoLab);
            return View(laboratorio);
        }

        // GET: Laboratorios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laboratorio laboratorio = db.Laboratorio.Find(id);
            if (laboratorio == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Asignado = new SelectList(db.Docente, "Id_Docente", "Nombre", laboratorio.Id_Asignado);
            ViewBag.Id_Encargado = new SelectList(db.PersonalAdministrativo, "Id_PersonalAdm", "Nombres", laboratorio.Id_Encargado);
            ViewBag.Id_Status = new SelectList(db.Status, "Id_Status", "Status1", laboratorio.Id_Status);
            ViewBag.Id_TipoLab = new SelectList(db.TipoLab, "Id_TipoLab", "Tipo_Lab", laboratorio.Id_TipoLab);
            return View(laboratorio);
        }

        // POST: Laboratorios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Lab,Id_Asignado,Id_Status,Id_Encargado,CapMax,NroEquipos,Id_TipoLab")] Laboratorio laboratorio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(laboratorio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Asignado = new SelectList(db.Docente, "Id_Docente", "Nombre", laboratorio.Id_Asignado);
            ViewBag.Id_Encargado = new SelectList(db.PersonalAdministrativo, "Id_PersonalAdm", "Nombres", laboratorio.Id_Encargado);
            ViewBag.Id_Status = new SelectList(db.Status, "Id_Status", "Status1", laboratorio.Id_Status);
            ViewBag.Id_TipoLab = new SelectList(db.TipoLab, "Id_TipoLab", "Tipo_Lab", laboratorio.Id_TipoLab);
            return View(laboratorio);
        }

        // GET: Laboratorios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laboratorio laboratorio = db.Laboratorio.Find(id);
            if (laboratorio == null)
            {
                return HttpNotFound();
            }
            return View(laboratorio);
        }

        // POST: Laboratorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Laboratorio laboratorio = db.Laboratorio.Find(id);
            db.Laboratorio.Remove(laboratorio);
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
