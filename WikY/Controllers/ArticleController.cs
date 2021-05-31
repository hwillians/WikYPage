using System.Linq;
using System.Web.Mvc;
using WikY.Models;

namespace WikY.Controllers
{
	public class ArticleController : Controller
	{
		// GET: Article
		public ActionResult Index()
		{
			WikYPageContext context = new WikYPageContext();
			Article art = context.Articles.OrderByDescending(x => x.DateCreation).FirstOrDefault();

			return View(art);
		}

		// GET: All Articles
		public ActionResult GetArticles()
		{
			WikYPageContext context = new WikYPageContext();
			var articles = context.Articles;

			return View(articles);
		}

		// GET: Article/Details/5
		public ActionResult Details(int id)
		{
			WikYPageContext context = new WikYPageContext();
			Article art = context.Articles.FirstOrDefault(a => a.Id == id);

			return View(art);
		}

		// GET: Article/Create
		public ActionResult Create()
		{
			ViewBag.isUnique = true;

			return View();
		}

		// POST: Article/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Article article)
		{
			WikYPageContext context = new WikYPageContext();
			if (ModelState.IsValid)
			{
				context.Articles.Add(article);
				context.SaveChanges();
				return RedirectToAction("GetArticles");
			}
			else return View();
		}

		// GET: Article/Edit/5
		public ActionResult Edit(int id)
		{
			WikYPageContext context = new WikYPageContext();
			var article = context.Articles.Find(id);
			return View(article);
		}

		// POST: Article/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, Article article)
		{
			WikYPageContext context = new WikYPageContext();
			if (ModelState.IsValid)
			{
				var oldArticle = context.Articles.Find(id);
				oldArticle.Auteur = article.Auteur;
				oldArticle.Contenu = article.Contenu;
				oldArticle.Theme = article.Theme;
				context.SaveChanges();
				return RedirectToAction("Details", new { id });
			}
			else return View();
		}

		// GET: Article/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Article/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, Article article)
		{
			WikYPageContext context = new WikYPageContext();

			var commentaires = context.Commentaires.Where(c => c.ArticleId == article.Id);
			foreach (var c in commentaires)
				context.Commentaires.Remove(context.Commentaires.Find(c.Id));

			var articleToRemove = context.Articles.Find(id);
			context.Articles.Remove(articleToRemove);
			context.SaveChanges();

			return RedirectToAction("GetArticles");
		}

		public ActionResult ThemeIsUnique(string theme, int? Id)
		{
			WikYPageContext context = new WikYPageContext();
			bool resp = !context.Articles.Any(a =>
			(Id == 0 ? a.Theme == theme : a.Theme == theme && a.Id != Id));

			return Json(resp, JsonRequestBehavior.AllowGet);
		}
	}
}
