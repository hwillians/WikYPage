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
			return View();
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
			return View();
		}

		// POST: Arcticle/Edit/5
		[HttpPost]
		public ActionResult Edit(int id, Article article)
		{
			try
			{
	

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
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
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
