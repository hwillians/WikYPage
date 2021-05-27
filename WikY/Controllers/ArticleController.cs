using System.Linq;
using System.Web.Mvc;
using WikY.Models;

namespace WikY.Controllers
{
	public class ArticleController : Controller
	{
		// GET: Arcticle
		public ActionResult Index()
		{
			WikYPageContext context = new WikYPageContext();
			Article art = context.Articles.OrderByDescending(x => x.DateCreation)
			  .FirstOrDefault();

			return View(art);
		}

		// GET: All Arcticles
		public ActionResult GetArticles()
		{
			WikYPageContext context = new WikYPageContext();
			var articles = context.Articles;

			return View(articles);
		}

		// GET: Arcticle/Details/5
		public ActionResult Details(int id)
		{
			WikYPageContext context = new WikYPageContext();
			Article art = context.Articles.FirstOrDefault(a => a.Id == id);
			return View(art);
		}

		// GET: Arcticle/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Arcticle/Create
		[HttpPost]
		public ActionResult Create(Article article)
		{
			if (ModelState.IsValid)
			{
				WikYPageContext context = new WikYPageContext();
				context.Articles.Add(article);
				context.SaveChanges();
				return RedirectToAction("GetArticles");
			}
			else return View();
		}

		// GET: Arcticle/Edit/5
		public ActionResult Edit(int id)
		{
			WikYPageContext context = new WikYPageContext();
			var article = context.Articles.Find(id);
			return View(article);

		}

		// POST: Arcticle/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, Article article)
		{
			WikYPageContext context = new WikYPageContext();
			var oldArticle = context.Articles.Find(id);
			oldArticle.Auteur = article.Auteur;
			oldArticle.Contenu = article.Contenu;
			oldArticle.Theme = article.Theme;
			context.SaveChanges();
			return RedirectToAction("Details", new { id });
		}

		// GET: Arcticle/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Arcticle/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, Article article)
		{
			WikYPageContext context = new WikYPageContext();
			var articleToRemove = context.Articles.Find(id);
			context.Articles.Remove(articleToRemove);
			context.SaveChanges();
			return RedirectToAction("GetArticles");
		}
	}
}
