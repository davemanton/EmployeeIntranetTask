using System.Collections.Generic;
using ViewModels;

namespace Application.Articles
{
	public interface IReadArticles
	{
		ArticleViewModel GetById(int articleId);
		ArticleViewModel GetById(int articleId, string username);
		IEnumerable<ArticleSummaryViewModel> GetSummaries();
		IEnumerable<ArticleSummaryViewModel> GetSummariesByUsername(string username);
	}
}