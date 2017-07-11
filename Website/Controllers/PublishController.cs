using System.Collections.Generic;
using System.Linq;
using Application.Articles;
using Domain.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace Website.Controllers
{
	[Authorize(Roles = "publisher")]
    public class PublishController : Controller
    {
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IReadArticles _articleReader;
	    private readonly IWriteArticles _articleWriter;

	    public PublishController(
			UserManager<ApplicationUser> userManager,
			IReadArticles articleReader, 
			IWriteArticles articleWriter)
	    {
		    _articleReader = articleReader;
		    _articleWriter = articleWriter;
		    _userManager = userManager;
	    }

	    public IActionResult Index()
	    {
		    var articles = _articleReader.GetSummariesByUsername(_userManager.GetUserName(User));

            return View(articles);
        }

	    public IActionResult Create()
	    {
		    return View(new ArticleViewModel());
	    }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(ArticleViewModel article)
		{
			article = _articleWriter.Create(article);

			if (article.ValidationErrors != null && article.ValidationErrors.Any())
			{
				AddErrors(article.ValidationErrors);

				return View(article);
			}

			return RedirectToAction("Index");
		}
		
	    public IActionResult Edit(int articleId)
	    {
		    var article = _articleReader.GetById(articleId);			

		    return View(article);
	    }

	    [HttpPost]
	    [ValidateAntiForgeryToken]
	    public IActionResult Edit(ArticleViewModel article)
	    {
		    article = _articleWriter.Update(article);

		    if (article.ValidationErrors != null && article.ValidationErrors.Any())
		    {
			    AddErrors(article.ValidationErrors);

			    return View(article);
		    }

		    return RedirectToAction("Index");
	    }

	    public IActionResult Delete(int articleId)
	    {
			_articleWriter.Delete(articleId);

		    return RedirectToAction("Index");
		}

		private void AddErrors(IEnumerable<string> errors)
	    {
		    foreach (var error in errors)
		    {
			    ModelState.AddModelError(string.Empty, error);
		    }
	    }
	}
}