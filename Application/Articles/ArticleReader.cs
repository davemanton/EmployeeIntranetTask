using System;
using System.Collections.Generic;
using System.Linq;
using Application.Employees;
using DataAccess.Repository;
using Domain;
using Remotion.Linq.Clauses;
using ViewModels;

namespace Application.Articles
{
	public class ArticleReader : IReadArticles
	{
		private readonly IGenericRepository<Article> _articleRepo;
		private readonly IReadEmployees _employeeReader;

		public ArticleReader(
			IGenericRepository<Article> articleRepo, 
			IReadEmployees employeeReader)
		{
			_articleRepo = articleRepo;
			_employeeReader = employeeReader;
		}

		public ArticleViewModel GetById(int articleId)
		{
			var article = _articleRepo.Get(x => x.ArticleId == articleId, x => x.Author, x => x.Likes).SingleOrDefault();

			if (article == null)
				return null;

			return new ArticleViewModel
			{
				ArticleId = article.ArticleId,
				Title = article.Title,
				Summary = article.Summary,
				Body = article.Body,
				Author = $"{article.Author.FirstName} {article.Author.LastName}",
				AuthorId = article.AuthorId,
				AuthorUsername = article.Author.Username,
				PublishedDate = article.PublishedDate,
				Likes = article.Likes.Count
			};
		}

		public ArticleViewModel GetById(int articleId, string username)
		{
			var employee = _employeeReader.GetByUsername(username);

			var article = _articleRepo.Get(x => x.ArticleId == articleId, x => x.Author, x => x.Likes).SingleOrDefault();

			if (article == null)
				return null;

			return new ArticleViewModel
			{
				ArticleId = article.ArticleId,
				Title = article.Title,
				Summary = article.Summary,
				Body = article.Body,
				Author = $"{article.Author.FirstName} {article.Author.LastName}",
				AuthorId = article.AuthorId,
				AuthorUsername = article.Author.Username,
				PublishedDate = article.PublishedDate,
				Likes = article.Likes.Count,
				Liked = article.Likes.Any(x => x.EmployeeId == employee.EmployeeId)
			};
		}

		public IEnumerable<ArticleSummaryViewModel> GetSummaries()
		{
			var articles = _articleRepo.Get(x => x.PublishedDate <= DateTime.UtcNow)
				.Select(x => new ArticleSummaryViewModel
				{
					ArticleId = x.ArticleId,
					Title = x.Title,
					Summary = x.Summary,
					AuthorId = x.AuthorId,
					PublishedDate = x.PublishedDate,
					Author = $"{x.Author.FirstName} {x.Author.LastName}"
				})
				.OrderByDescending(x => x.PublishedDate);

			return articles;
		}

		public IEnumerable<ArticleSummaryViewModel> GetSummariesByUsername(string username)
		{
			var articles =_articleRepo.Get(x => x.Author.Username.Equals(username, StringComparison.OrdinalIgnoreCase), x => x.Author)
				.Select(x => new ArticleSummaryViewModel
				{
					ArticleId = x.ArticleId,
					Title = x.Title,
					Summary = x.Summary,					
					AuthorId = x.AuthorId,
					PublishedDate = x.PublishedDate,
					Author = $"{x.Author.FirstName} {x.Author.LastName}"
				})
				.OrderByDescending(x => x.ArticleId);

			return articles;						
		}		
	}
}