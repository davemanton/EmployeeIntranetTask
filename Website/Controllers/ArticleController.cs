using Application.ArticleLikes;
using Application.Articles;
using Domain.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers
{
	[Authorize]
    public class ArticleController : Controller
    {
	    private readonly IReadArticles _articleReader;
	    private readonly IWriteArticleLikes _articleLikeWriter;
		
	    public ArticleController(
			IReadArticles articleReader, 
			IWriteArticleLikes articleLikeWriter)
	    {
		    _articleReader = articleReader;
		    _articleLikeWriter = articleLikeWriter;
	    }

	    public IActionResult Index(int articleId)
        {	        
			var article = _articleReader.GetById(articleId, User.Identity.Name);

            return View(article);            
        }

	    public IActionResult ToggleLike(int articleId)
	    {
			_articleLikeWriter.Toggle(articleId, User.Identity.Name);

		    return RedirectToAction("Index", new { articleId = articleId });
		}
    }
}