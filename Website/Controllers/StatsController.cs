using Application.Stats;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers
{
    public class StatsController : Controller
    {
	    private readonly ICalculateArticleStatistics _articleStatisticsCalculator;

	    public StatsController(ICalculateArticleStatistics articleStatisticsCalculator)
	    {
		    _articleStatisticsCalculator = articleStatisticsCalculator;
	    }

	    public IActionResult Index()
	    {
            return View();
        }

	    public IActionResult ArticleLikes()
	    {
		    var stats = _articleStatisticsCalculator.GetArticleLikesStats();

		    return View(stats);
	    }
	}
}