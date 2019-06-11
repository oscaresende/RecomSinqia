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
    public class TiposFalhasController : Controller
    {
        private RecomSinqiaContexto db = new RecomSinqiaContexto();

        // GET: TiposFalhas
        public ActionResult Index()
        {
            return View(db.TipoFalha.ToList());
        }

        // GET: TiposFalhas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoFalha tipoFalha = db.TipoFalha.Find(id);
            if (tipoFalha == null)
            {
                return HttpNotFound();
            }
            return View(tipoFalha);
        }

        // GET: TiposFalhas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposFalhas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Sigla")] TipoFalha tipoFalha)
        {
            if (ModelState.IsValid)
            {
                db.TipoFalha.Add(tipoFalha);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoFalha);
        }

        // GET: TiposFalhas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoFalha tipoFalha = db.TipoFalha.Find(id);
            if (tipoFalha == null)
            {
                return HttpNotFound();
            }
            return View(tipoFalha);
        }

        // POST: TiposFalhas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Sigla")] TipoFalha tipoFalha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoFalha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoFalha);
        }

        // GET: TiposFalhas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoFalha tipoFalha = db.TipoFalha.Find(id);
            if (tipoFalha == null)
            {
                return HttpNotFound();
            }
            return View(tipoFalha);
        }

        // POST: TiposFalhas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoFalha tipoFalha = db.TipoFalha.Find(id);
            db.TipoFalha.Remove(tipoFalha);
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
