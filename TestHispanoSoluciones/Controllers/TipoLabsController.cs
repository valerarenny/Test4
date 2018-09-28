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
    public class TipoLabsController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        // GET: TipoLabs
        public ActionResult Index()
        {
            return View(db.TipoLab.ToList());
        }

        // GET: TipoLabs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLab tipoLab = db.TipoLab.Find(id);
            if (tipoLab == null)
            {
                return HttpNotFound();
            }
            return View(tipoLab);
        }

        // GET: TipoLabs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoLabs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_TipoLab,Tipo_Lab")] TipoLab tipoLab)
        {
            if (ModelState.IsValid)
            {
                db.TipoLab.Add(tipoLab);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoLab);
        }

        // GET: TipoLabs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLab tipoLab = db.TipoLab.Find(id);
            if (tipoLab == null)
            {
                return HttpNotFound();
            }
            return View(tipoLab);
        }

        // POST: TipoLabs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_TipoLab,Tipo_Lab")] TipoLab tipoLab)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoLab).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoLab);
        }

        // GET: TipoLabs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoLab tipoLab = db.TipoLab.Find(id);
            if (tipoLab == null)
            {
                return HttpNotFound();
            }
            return View(tipoLab);
        }

        // POST: TipoLabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoLab tipoLab = db.TipoLab.Find(id);
            db.TipoLab.Remove(tipoLab);
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
