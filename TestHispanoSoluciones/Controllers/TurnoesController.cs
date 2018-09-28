﻿using System;
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
    public class TurnoesController : Controller
    {
        private UniversityDbContext db = new UniversityDbContext();

        // GET: Turnoes
        public ActionResult Index()
        {
            var turno = db.Turno.Include(t => t.Dias).Include(t => t.Dias1);
            return View(turno.ToList());
        }

        // GET: Turnoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turno turno = db.Turno.Find(id);
            if (turno == null)
            {
                return HttpNotFound();
            }
            return View(turno);
        }

        // GET: Turnoes/Create
        public ActionResult Create()
        {
            ViewBag.Dia_Desde = new SelectList(db.Dias, "Id_Dias", "Dias1");
            ViewBag.Dia_Hasta = new SelectList(db.Dias, "Id_Dias", "Dias1");
            return View();
        }

        // POST: Turnoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Turno,Hora_Ini,Hora_Fin,Dia_Desde,Dia_Hasta")] Turno turno)
        {
            if (ModelState.IsValid)
            {
                db.Turno.Add(turno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Dia_Desde = new SelectList(db.Dias, "Id_Dias", "Dias1", turno.Dia_Desde);
            ViewBag.Dia_Hasta = new SelectList(db.Dias, "Id_Dias", "Dias1", turno.Dia_Hasta);
            return View(turno);
        }

        // GET: Turnoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turno turno = db.Turno.Find(id);
            if (turno == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dia_Desde = new SelectList(db.Dias, "Id_Dias", "Dias1", turno.Dia_Desde);
            ViewBag.Dia_Hasta = new SelectList(db.Dias, "Id_Dias", "Dias1", turno.Dia_Hasta);
            return View(turno);
        }

        // POST: Turnoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Turno,Hora_Ini,Hora_Fin,Dia_Desde,Dia_Hasta")] Turno turno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(turno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dia_Desde = new SelectList(db.Dias, "Id_Dias", "Dias1", turno.Dia_Desde);
            ViewBag.Dia_Hasta = new SelectList(db.Dias, "Id_Dias", "Dias1", turno.Dia_Hasta);
            return View(turno);
        }

        // GET: Turnoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turno turno = db.Turno.Find(id);
            if (turno == null)
            {
                return HttpNotFound();
            }
            return View(turno);
        }

        // POST: Turnoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Turno turno = db.Turno.Find(id);
            db.Turno.Remove(turno);
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
