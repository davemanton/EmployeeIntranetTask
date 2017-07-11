using ViewModels;

namespace Application.Articles
{
	public interface IWriteArticles
	{
		ArticleViewModel Create(ArticleViewModel article);
		ArticleViewModel Update(ArticleViewModel article);
		void Delete(int articleId);
	}
}