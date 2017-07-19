using System.Collections.Generic;
using System.Linq;
using Application.Employees;
using Application.Validators;
using DataAccess.Repository;
using Domain;
using ViewModels;

namespace Application.Articles
{
	public class ArticleWriter : IWriteArticles
	{
		private readonly IValidate<ArticleViewModel> _viewModelValidator;
		private readonly IReadEmployees _employeeReader;
		private readonly IGenericRepository<Article> _articleRepo;
		private readonly IUnitOfWork _uow;

		public ArticleWriter(
			IValidate<ArticleViewModel> viewModelValidator,
			IReadEmployees employeeReader, 
			IGenericRepository<Article> articleRepo, 
			IUnitOfWork uow
			)
		{
			_viewModelValidator = viewModelValidator;
			_employeeReader = employeeReader;
			_articleRepo = articleRepo;
			_uow = uow;
		}

		public ArticleViewModel Create(ArticleViewModel articleVm)
		{
			if (articleVm == null)
				return null;

			IEnumerable<string> errors;
			if (_viewModelValidator.Validate(articleVm, out errors))
			{
				articleVm.ValidationErrors = errors;
				return articleVm;
			}

			var author = _employeeReader.GetByUsername(articleVm.AuthorUsername);

			var article = new Article(author.EmployeeId, articleVm.Title, articleVm.Summary, articleVm.Body, articleVm.PublishedDate);

			article = _articleRepo.Insert(article);

			try
			{
				_uow.Save();

				articleVm.ArticleId = article.ArticleId;
			}
			catch
			{
				return null;
			}

			return articleVm;
		}

		public ArticleViewModel Update(ArticleViewModel articleVm)
		{
			if (articleVm == null)
				return null;

			IEnumerable<string> errors;
			if (_viewModelValidator.Validate(articleVm, out errors))
			{
				articleVm.ValidationErrors = errors;
				return articleVm;
			}

			var article = _articleRepo.Get(x => x.ArticleId == articleVm.ArticleId).SingleOrDefault();

			if (article == null)
				return Create(articleVm);			

			article.Update(articleVm.AuthorId, articleVm.Title, articleVm.Summary, articleVm.Body, articleVm.PublishedDate);

			try
			{
				_uow.Save();
			}
			catch
			{
				return null;
			}

			return articleVm;
		}

		public void Delete(int articleId)
		{
			_articleRepo.Delete(articleId);

			_uow.Save();
		}
	}
}