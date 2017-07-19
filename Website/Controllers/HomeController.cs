using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Articles;
using Domain.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
	    private readonly UserManager<ApplicationUser> _userManager;
	    private readonly IReadArticles _articleReader;

	    public HomeController(UserManager<ApplicationUser> userManager, IReadArticles articleReader)
	    {
		    _userManager = userManager;
		    _articleReader = articleReader;
	    }

	    public async Task<IActionResult> Index()
	    {
		    var user = await GetCurrentUserAsync();

			if(user == null)
				return View(new List<ArticleSummaryViewModel>());

		    var articles = _articleReader.GetSummaries();

		    return View(articles.ToList());
	    }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

	    private Task<ApplicationUser> GetCurrentUserAsync()
	    {
		    return _userManager.GetUserAsync(HttpContext.User);
	    }
	}
}
