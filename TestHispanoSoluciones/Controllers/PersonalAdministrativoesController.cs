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
    public class PersonalAdministrativoesController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        // GET: PersonalAdministrativoes
        public ActionResult Index()
        {
            var personalAdministrativo = db.PersonalAdministrativo.Include(p => p.Departamento).Include(p => p.Rol).Include(p => p.Status).Include(p => p.Turno);
            return View(personalAdministrativo.ToList());
        }

        // GET: PersonalAdministrativoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalAdministrativo personalAdministrativo = db.PersonalAdministrativo.Find(id);
            if (personalAdministrativo == null)
            {
                return HttpNotFound();
            }
            return View(personalAdministrativo);
        }

        // GET: PersonalAdministrativoes/Create
        public ActionResult Create()
        {
            ViewBag.Id_Departamento = new SelectList(db.Departamento, "Id_Departamento", "Departamento1");
            ViewBag.Id_Rol = new SelectList(db.Rol, "Id_Rol", "Rol1");
            ViewBag.Id_Status = new SelectList(db.Status, "Id_Status", "Status1");
            ViewBag.Id_Turno = new SelectList(db.Turno, "Id_Turno", "Id_Turno");
            return View();
        }

        // POST: PersonalAdministrativoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_PersonalAdm,Nombres,Apellidos,DNI,Id_Rol,Id_Status,Id_Turno,Id_Departamento")] PersonalAdministrativo personalAdministrativo)
        {
            if (ModelState.IsValid)
            {
                db.PersonalAdministrativo.Add(personalAdministrativo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Departamento = new SelectList(db.Departamento, "Id_Departamento", "Departamento1", personalAdministrativo.Id_Departamento);
            ViewBag.Id_Rol = new SelectList(db.Rol, "Id_Rol", "Rol1", personalAdministrativo.Id_Rol);
            ViewBag.Id_Status = new SelectList(db.Status, "Id_Status", "Status1", personalAdministrativo.Id_Status);
            ViewBag.Id_Turno = new SelectList(db.Turno, "Id_Turno", "Id_Turno", personalAdministrativo.Id_Turno);
            return View(personalAdministrativo);
        }

        // GET: PersonalAdministrativoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalAdministrativo personalAdministrativo = db.PersonalAdministrativo.Find(id);
            if (personalAdministrativo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Departamento = new SelectList(db.Departamento, "Id_Departamento", "Departamento1", personalAdministrativo.Id_Departamento);
            ViewBag.Id_Rol = new SelectList(db.Rol, "Id_Rol", "Rol1", personalAdministrativo.Id_Rol);
            ViewBag.Id_Status = new SelectList(db.Status, "Id_Status", "Status1", personalAdministrativo.Id_Status);
            ViewBag.Id_Turno = new SelectList(db.Turno, "Id_Turno", "Id_Turno", personalAdministrativo.Id_Turno);
            return View(personalAdministrativo);
        }

        // POST: PersonalAdministrativoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_PersonalAdm,Nombres,Apellidos,DNI,Id_Rol,Id_Status,Id_Turno,Id_Departamento")] PersonalAdministrativo personalAdministrativo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personalAdministrativo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Departamento = new SelectList(db.Departamento, "Id_Departamento", "Departamento1", personalAdministrativo.Id_Departamento);
            ViewBag.Id_Rol = new SelectList(db.Rol, "Id_Rol", "Rol1", personalAdministrativo.Id_Rol);
            ViewBag.Id_Status = new SelectList(db.Status, "Id_Status", "Status1", personalAdministrativo.Id_Status);
            ViewBag.Id_Turno = new SelectList(db.Turno, "Id_Turno", "Id_Turno", personalAdministrativo.Id_Turno);
            return View(personalAdministrativo);
        }

        // GET: PersonalAdministrativoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalAdministrativo personalAdministrativo = db.PersonalAdministrativo.Find(id);
            if (personalAdministrativo == null)
            {
                return HttpNotFound();
            }
            return View(personalAdministrativo);
        }

        // POST: PersonalAdministrativoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonalAdministrativo personalAdministrativo = db.PersonalAdministrativo.Find(id);
            db.PersonalAdministrativo.Remove(personalAdministrativo);
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
