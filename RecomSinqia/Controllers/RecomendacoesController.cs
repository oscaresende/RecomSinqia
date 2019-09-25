using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Accord.IO;
using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Math;
using Accord.Math.Optimization.Losses;
using Accord.Statistics.Filters;
using Accord.Statistics.Kernels;
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
            var recomendacoes = db.Recomendacao.Include(r => r.Classificacao).Include(r => r.Colaborador).Include(r => r.Dificuldade).Include(r => r.Gerencia).Include(r => r.Cliente).Include(r => r.Sistema).Include(r => r.TipoFalha).Include(r => r.Prioridade).Include(r => r.Modulo);
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
            ViewBag.SistemaId = new SelectList(db.Sistema, "Id", "Nome");
            ViewBag.ClienteId = new SelectList(db.Cliente, "Id", "Nome");
            ViewBag.TipoFalhaId = new SelectList(db.TipoFalha, "Id", "Nome");
			ViewBag.PrioridadeId = new SelectList(db.Prioridade, "Id", "Nome");
            ViewBag.ModuloId = new SelectList(db.Modulo, "Id", "Nome");
            return View();
        }

		// POST: Recomendacoes/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GerenciaId,ClienteId,SistemaId,ModuloId,ClassificacaoId,TipoFalhaId,PrioridadeId,DificuldadeId,ColaboradorId,Observacao")] Recomendacao recomendacao, string submitButton)
        {
            switch (submitButton)
            {
                case "Recomendar":

                    ViewBag.ClassificacaoId = new SelectList(db.Classificacao, "Id", "Nome", recomendacao.ClassificacaoId);
                    ViewBag.DificuldadeId = new SelectList(db.Dificuldade, "Id", "Nome", recomendacao.DificuldadeId);
                    ViewBag.GerenciaId = new SelectList(db.Gerencia, "Id", "Nome", recomendacao.GerenciaId);
                    ViewBag.TipoFalhaId = new SelectList(db.TipoFalha, "Id", "Nome", recomendacao.TipoFalhaId);
                    ViewBag.PrioridadeId = new SelectList(db.Prioridade, "Id", "Nome", recomendacao.PrioridadeId);
                    ViewBag.ClienteId = new SelectList(db.Cliente, "Id", "Nome", recomendacao.ClienteId);
                    ViewBag.SistemaId = new SelectList(db.Sistema, "Id", "Nome", recomendacao.SistemaId);


                    //aqui é realizado o algoritmo de recomendação do colaborador                    
                    ViewBag.ColaboradorId = new SelectList(metodoquedefineoscolaboradores(recomendacao.GerenciaId,
                                                                                          recomendacao.ClassificacaoId,
                                                                                          recomendacao.DificuldadeId,
                                                                                          recomendacao.PrioridadeId,
                                                                                          recomendacao.TipoFalhaId),
                                                           "Id", "Nome", recomendacao.ColaboradorId);

                    return View(recomendacao);

                default:

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
                    ViewBag.ClienteId = new SelectList(db.Cliente, "Id", "Nome", recomendacao.ClienteId);
                    ViewBag.SistemaId = new SelectList(db.Sistema, "Id", "Nome", recomendacao.SistemaId);

                    return View(recomendacao);

            }
        }

        private List<Colaborador> metodoquedefineoscolaboradores(int pGerencia, int pClassificacao, int pDificuldade, int pPrioridade, int pTipoFalha)
        {
            string filename = "C:/Users/Oscar/Downloads/solics-completo.csv";
            CsvReader reader = new CsvReader(filename, hasHeaders: true);

            DataTable table = reader.ToTable();

            string[] inputNames = new[] { "Id", "Gerencia", "Cliente", "Sistema", "Modulo", "Classificacao", "TipoFalha", "Prioridade", "Dificuldade" };
            string[] outputNames = new[] { "Colaborador" };

            /*var codification1 = new Codification()
            {
                { "Id", CodificationVariable.Ordinal},
                { "Gerencia", CodificationVariable.Discrete },
                { "Cliente", CodificationVariable.Discrete },
                { "Sistema", CodificationVariable.Discrete },
                { "Modulo", CodificationVariable.Discrete },
                { "Classificacao", CodificationVariable.Discrete},                
                { "TipoFalha", CodificationVariable.Discrete },
                { "Prioridade", CodificationVariable.Discrete },
                { "Dificuldade", CodificationVariable.Discrete },
            };
            
            var codification2 = new Codification()
            {
                DefaultMissingValueReplacement = Double.NaN
            };
            
            codification1.Learn(table);
            codification2.Learn(table); 

             */

            Codification codebook = new Codification(table);
                        
            
            //DataTable symbols = codification.Apply(table);
            //int[] outputis = symbols.ToArray<int>("COLABORADOR");

            // Now, transform symbols into a vector representation, growing the number of inputs:
            //double[][] x = codification.Transform(table, inputNames, out inputNames).ToDouble();
            int[][] x = codebook.Apply(table, "Id", "Gerencia", "Cliente", "Sistema", "Modulo", "Classificacao", "TipoFalha", "Prioridade", "Dificuldade").ToJagged(out inputNames).ToInt32();
            //double[][] y = codification.Transform(table, outputNames, out outputNames).ToDouble();
            //int[] y = codification.Apply(table, "COLABORADOR").ToJagged(out outputName);

            string outputName;    // can see below the new variable names that will be generated)
            int[] outputs = codebook.Apply(table, "Colaborador").ToVector(out outputName).ToInt32();



            /*
            // Create the multi-class learning algorithm for the machine
            var teacher = new MultilabelSupportVectorLearning<Gaussian>()
            {
                // Configure the learning algorithm to use SMO to train the
                //  underlying SVMs in each of the binary class subproblems.
                Learner = (param) => new SequentialMinimalOptimization<Gaussian>()
                {
                    // Estimate a suitable guess for the Gaussian kernel's parameters.
                    // This estimate can serve as a starting point for a grid search.
                    UseKernelEstimation = true
                }
            };

            // Learn a machine
            var machine = teacher.Learn(x, outputs);

            // Create the multi-class learning algorithm for the machine
            var calibration = new MultilabelSupportVectorLearning<Gaussian>()
            {
                Model = machine, // We will start with an existing machine

                // Configure the learning algorithm to use SMO to train the
                //  underlying SVMs in each of the binary class subproblems.
                Learner = (param) => new ProbabilisticOutputCalibration<Gaussian>()
                {
                    Model = param.Model // Start with an existing machine
                }
            };


            // Configure parallel execution options
            calibration.ParallelOptions.MaxDegreeOfParallelism = 1;

            // Learn a machine
            calibration.Learn(x, outputs);

            // Obtain class predictions for each sample
            bool[][] predicted = machine.Decide(x);

            // Get class scores for each sample
            double[][] scores = machine.Scores(x);

            // Get log-likelihoods (should be same as scores)
            double[][] logl = machine.LogLikelihoods(x);

            // Get probability for each sample
            double[][] prob = machine.Probabilities(x);

            // Compute classification error using mean accuracy (mAcc)
            double error = new HammingLoss(outputs).Loss(predicted);
            double loss = new CategoryCrossEntropyLoss(outputs).Loss(prob);*/

            Accord.Math.Random.Generator.Seed = 1;
            DecisionVariable[] Attributes = DecisionVariable.FromCodebook(codebook, inputNames);

            // Now, let's create the forest learning algorithm
            var teacher = new RandomForestLearning(Attributes)
            {
                NumberOfTrees = 1,
                SampleRatio = 1.0
            };

            // Finally, learn a random forest from data
            var forest = teacher.Learn(x, outputs);

            // We can estimate class labels using
            int[] predicted = forest.Decide(x);

            // And the classification error (0) can be computed as 
            double error = new ZeroOneLoss(outputs).Loss(forest.Decide(x));

            // Compute classification error using mean accuracy (mAcc)
            double error2 = new HammingLoss(outputs).Loss(predicted);            

            List<Colaborador> lLista = new List<Colaborador>();
            //lLista.AddRange(db.Colaborador.Where(x => x.Nome.StartsWith("J")).OrderBy(x => x.Nome));
            return lLista;
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
            ViewBag.ClienteId = new SelectList(db.Cliente, "Id", "Nome", recomendacao.ClienteId);
            ViewBag.SistemaId = new SelectList(db.Sistema, "Id", "Nome", recomendacao.SistemaId);
            ViewBag.TipoFalhaId = new SelectList(db.TipoFalha, "Id", "Nome", recomendacao.TipoFalhaId);
			ViewBag.PrioridadeId = new SelectList(db.Prioridade, "Id", "Nome", recomendacao.PrioridadeId);
            ViewBag.ModuloId = new SelectList(db.Modulo, "Id", "Nome", recomendacao.ModuloId);
            return View(recomendacao);
        }

        // POST: Recomendacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GerenciaId,ClienteId,SistemaId,ModuloId,ClassificacaoId,TipoFalhaId,PrioridadeId,DificuldadeId,ColaboradorId,Observacao")] Recomendacao recomendacao)
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
            ViewBag.ClienteId = new SelectList(db.Cliente, "Id", "Nome", recomendacao.ClienteId);
            ViewBag.SistemaId = new SelectList(db.Sistema, "Id", "Nome", recomendacao.SistemaId);
            ViewBag.TipoFalhaId = new SelectList(db.TipoFalha, "Id", "Nome", recomendacao.TipoFalhaId);
			ViewBag.PrioridadeId = new SelectList(db.Prioridade, "Id", "Nome", recomendacao.PrioridadeId);
            ViewBag.ModuloId = new SelectList(db.Modulo, "Id", "Nome", recomendacao.ModuloId);
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
