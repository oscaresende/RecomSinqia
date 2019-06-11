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
    public class RecomendacoesController : Controller
    {
        private RecomSinqiaContexto db = new RecomSinqiaContexto();

        // GET: Recomendacoes
        public ActionResult Index()
        {
            var recomendacoes = db.Recomendacao.Include(r => r.Classificacao).Include(r => r.Colaborador).Include(r => r.Dificuldade).Include(r => r.Gerencia).Include(r => r.TipoFalha).Include(r => r.Prioridade);
            return View(recomendacoes.ToList());
        }

        // GET: Recomendacoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recomendacao recomendacao = db.Recomendacao.Find(id);
            if (recomendacao == null)
            {
                return HttpNotFound();
            }
            return View(recomendacao);
        }

        // GET: Recomendacoes/Create
        public ActionResult Create()
        {
            ViewBag.ClassificacaoId = new SelectList(db.Classificacao, "Id", "Nome");
            ViewBag.ColaboradorId = new SelectList(new List<Colaborador>(), "Id", "Nome");
            ViewBag.DificuldadeId = new SelectList(db.Dificuldade, "Id", "Nome");
            ViewBag.GerenciaId = new SelectList(db.Gerencia, "Id", "Nome");
            ViewBag.TipoFalhaId = new SelectList(db.TipoFalha, "Id", "Nome");
			ViewBag.PrioridadeId = new SelectList(db.Prioridade, "Id", "Nome");
			return View();
        }

		// POST: Recomendacoes/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Observacao,GerenciaId,ClassificacaoId,TipoFalhaId,DificuldadeId,PrioridadeId,ColaboradorId")] Recomendacao recomendacao)
        {
            if (ModelState.IsValid)
            {
                db.Recomendacao.Add(recomendacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassificacaoId = new SelectList(db.Classificacao, "Id", "Nome", recomendacao.ClassificacaoId);
            ViewBag.ColaboradorId = new SelectList(db.Colaborador, "Id", "Nome", recomendacao.ColaboradorId);
            ViewBag.DificuldadeId = new SelectList(db.Dificuldade, "Id", "Nome", recomendacao.DificuldadeId);
            ViewBag.GerenciaId = new SelectList(db.Gerencia, "Id", "Nome", recomendacao.GerenciaId);
            ViewBag.TipoFalhaId = new SelectList(db.TipoFalha, "Id", "Nome", recomendacao.TipoFalhaId);
			ViewBag.PrioridadeId = new SelectList(db.Prioridade, "Id", "Nome", recomendacao.PrioridadeId);
			return View(recomendacao);
        }

        // GET: Recomendacoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recomendacao recomendacao = db.Recomendacao.Find(id);
            if (recomendacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassificacaoId = new SelectList(db.Classificacao, "Id", "Nome", recomendacao.ClassificacaoId);
            ViewBag.ColaboradorId = new SelectList(db.Colaborador, "Id", "Nome", recomendacao.ColaboradorId);
            ViewBag.DificuldadeId = new SelectList(db.Dificuldade, "Id", "Nome", recomendacao.DificuldadeId);
            ViewBag.GerenciaId = new SelectList(db.Gerencia, "Id", "Nome", recomendacao.GerenciaId);
            ViewBag.TipoFalhaId = new SelectList(db.TipoFalha, "Id", "Nome", recomendacao.TipoFalhaId);
			ViewBag.PrioridadeId = new SelectList(db.Prioridade, "Id", "Nome", recomendacao.PrioridadeId);
			return View(recomendacao);
        }

        // POST: Recomendacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Observacao,GerenciaId,ClassificacaoId,TipoFalhaId,DificuldadeId,PrioridadeId,ColaboradorId")] Recomendacao recomendacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recomendacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassificacaoId = new SelectList(db.Classificacao, "Id", "Nome", recomendacao.ClassificacaoId);
            ViewBag.ColaboradorId = new SelectList(db.Colaborador, "Id", "Nome", recomendacao.ColaboradorId);
            ViewBag.DificuldadeId = new SelectList(db.Dificuldade, "Id", "Nome", recomendacao.DificuldadeId);
            ViewBag.GerenciaId = new SelectList(db.Gerencia, "Id", "Nome", recomendacao.GerenciaId);
            ViewBag.TipoFalhaId = new SelectList(db.TipoFalha, "Id", "Nome", recomendacao.TipoFalhaId);
			ViewBag.PrioridadeId = new SelectList(db.Prioridade, "Id", "Nome", recomendacao.PrioridadeId);
			return View(recomendacao);
        }

        // GET: Recomendacoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recomendacao recomendacao = db.Recomendacao.Find(id);
            if (recomendacao == null)
            {
                return HttpNotFound();
            }
            return View(recomendacao);
        }

        // POST: Recomendacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recomendacao recomendacao = db.Recomendacao.Find(id);
            db.Recomendacao.Remove(recomendacao);
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
