using Application.Articles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers
{
	[Authorize]
    public class ArticleController : Controller
    {
	    private readonly IReadArticles _articleReader;

	    public ArticleController(IReadArticles articleReader)
	    {
		    _articleReader = articleReader;
	    }

	    public IActionResult Index(int articleId)
        {
			var article = _articleReader.GetById(articleId);

            return View(article);
        }
    }
}