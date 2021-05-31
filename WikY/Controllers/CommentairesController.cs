using System.Linq;
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
			}
			return RedirectToAction("Details", "Article", new { id = commentaire.ArticleId });
		}

		// GET: Commentaires/Create
		public ActionResult CreatePartial(int idArticle)
		{
			WikYPageContext context = new WikYPageContext();
			var article = context.Articles.Find(idArticle);
			ViewBag.articleId = context.Articles.Find(idArticle).Id;

			return PartialView("_ZoneCommentaires", article.Commentaires);
		}

		// POST: Commentaires/Create
		[HttpPost]
		public ActionResult CreatePartial(int articleId, Commentaire commentaire)
		{
			WikYPageContext context = new WikYPageContext();
			if (ModelState.IsValid)
			{
				context.Commentaires.Add(commentaire);
				context.SaveChanges();
			}
			var commentaires = context.Commentaires.Where(c => c.ArticleId == articleId);
			return PartialView("_ZoneCommentaires", commentaires);
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
