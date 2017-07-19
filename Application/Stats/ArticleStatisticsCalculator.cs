using System;
using System.Linq;
using DataAccess.Repository;
using Domain;
using ViewModels;

namespace Application.Stats
{
	public class ArticleStatisticsCalculator : ICalculateArticleStatistics
	{
		private readonly IGenericRepository<Article> _articleRepo;

		public ArticleStatisticsCalculator(IGenericRepository<Article> articleRepo)
		{
			_articleRepo = articleRepo;
		}

		public ArticleLikesStatsViewModel GetArticleLikesStats()
		{
			var stats = _articleRepo.Get(x => x.PublishedDate <= DateTime.UtcNow, x => x.Likes)
				.ToDictionary(
					x => x.ArticleId,
					x => new ArticleLikesSummaryViewModel
					{
						Title = x.Title,
						Likes = x.Likes.Count
					});

			return new ArticleLikesStatsViewModel
			{
				ArticleLikesStats = stats
			};
		}
	}
}