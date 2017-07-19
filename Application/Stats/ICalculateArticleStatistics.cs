using ViewModels;

namespace Application.Stats
{
	public interface ICalculateArticleStatistics
	{
		ArticleLikesStatsViewModel GetArticleLikesStats();
	}
}