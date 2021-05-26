using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WikY.Models;

namespace WikY.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			WikYPageContext context = new WikYPageContext();
			Article art = context.Articles.OrderByDescending(x => x.DateCreation)
			  .FirstOrDefault(); ;

			return View(art);
		}

		public ActionResult GetArticles()
		{
			WikYPageContext context = new WikYPageContext();
			var articles = context.Articles;

			return View(articles);
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}