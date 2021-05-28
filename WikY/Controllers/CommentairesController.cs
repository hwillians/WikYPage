using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WikY.Models;

namespace WikY.Controllers
{
	public class CommentairesController : Controller
	{
		// GET: Commentaires
		public ActionResult Index()
		{
			return View();
		}

		// GET: Commentaires/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Commentaires/Create
		public ActionResult Create(int idArticle)
		{
			WikYPageContext context = new WikYPageContext();
			ViewBag.articleId = context.Articles.Find(idArticle).Id;
			return View();
		}

		// POST: Commentaires/Create
		[HttpPost]
		public ActionResult Create(Commentaire commentaire)
		{
			if (ModelState.IsValid)
			{
				WikYPageContext context = new WikYPageContext();
				context.Commentaires.Add(commentaire);
				context.SaveChanges();
				return RedirectToAction("Details", "Article",new { id = commentaire.ArticleId });
			}
			else return View();

		}

		// GET: Commentaires/Delete/5
		public ActionResult Delete(int id)
		{
			WikYPageContext context = new WikYPageContext();
			var commentaireToRemove = context.Commentaires.Find(id);
			return View(commentaireToRemove);
		}

		// POST: Commentaires/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, Commentaire commentaire)
		{
			WikYPageContext context = new WikYPageContext();
			var commentaireToRemove = context.Commentaires.Find(id);
			context.Commentaires.Remove(commentaireToRemove);
			context.SaveChanges();
			return RedirectToAction("Details", "Article", new { id = commentaire.ArticleId });
		}
	}
}
