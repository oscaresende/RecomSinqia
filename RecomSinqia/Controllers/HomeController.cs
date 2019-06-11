using RecomSinqia.AcessoDados;
using RecomSinqia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecomSinqia.Controllers
{
	public class HomeController : Controller
	{
		private RecomSinqiaContexto db = new RecomSinqiaContexto();
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			List<Gerencia> Gerencias = db.Gerencia.ToList();
					
			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}