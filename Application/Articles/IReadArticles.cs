using System.Collections.Generic;
using ViewModels;

namespace Application.Articles
{
	public interface IReadArticles
	{
		ArticleViewModel GetById(int articleId);
		IEnumerable<ArticleSummaryViewModel> GetSummaries();
		IEnumerable<ArticleSummaryViewModel> GetSummariesByUsername(string username);
	}
}