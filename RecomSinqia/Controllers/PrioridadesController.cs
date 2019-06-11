using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecomSinqia.AcessoDados;
using RecomSinqia.Models;

namespace RecomSinqia.Controllers
{
    public class PrioridadesController : Controller
    {
        private RecomSinqiaContexto db = new RecomSinqiaContexto();

        // GET: Prioridades
        public ActionResult Index()
        {
            return View(db.Prioridade.ToList());
        }

        // GET: Prioridades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prioridade prioridade = db.Prioridade.Find(id);
            if (prioridade == null)
            {
                return HttpNotFound();
            }
            return View(prioridade);
        }

        // GET: Prioridades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prioridades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Sigla")] Prioridade prioridade)
        {
            if (ModelState.IsValid)
            {
                db.Prioridade.Add(prioridade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prioridade);
        }

        // GET: Prioridades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prioridade prioridade = db.Prioridade.Find(id);
            if (prioridade == null)
            {
                return HttpNotFound();
            }
            return View(prioridade);
        }

        // POST: Prioridades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Sigla")] Prioridade prioridade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prioridade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prioridade);
        }

        // GET: Prioridades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prioridade prioridade = db.Prioridade.Find(id);
            if (prioridade == null)
            {
                return HttpNotFound();
            }
            return View(prioridade);
        }

        // POST: Prioridades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prioridade prioridade = db.Prioridade.Find(id);
            db.Prioridade.Remove(prioridade);
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
