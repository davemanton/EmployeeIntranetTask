using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.Articles;
using Application.Employees;
using Application.Validators;
using DataAccess.Repository;
using Domain;
using Moq;
using TestLibrary.DomainBuilder;
using TestLibrary.Helpers;
using TestLibrary.ViewModelBuilders;
using ViewModels;

namespace Application.Tests.Articles
{
	internal class ArticleWriterTestWrapper
	{
		public ArticleWriterTestWrapper()
		{
			ArticleViewModelValidator = new ArticleViewModelValidator();
			EmployeeReader = new Mock<IReadEmployees>();
			ArticleRepo = new Mock<IGenericRepository<Article>>();
			UoW = new Mock<IUnitOfWork>();

			ArticleViewModelBuilder = new ArticleViewModelBuilder();
			InsertArticleViewModel = ArticleViewModelBuilder.BuildNew().Object;
			UpdateArticleViewModel = ArticleViewModelBuilder.BuildUpdate().Object;

			Author = new EmployeeBuilder().Build().Object;

			ReturnedArticle = new Article(Author.EmployeeId, InsertArticleViewModel.Title, InsertArticleViewModel.Summary,
				InsertArticleViewModel.Body, InsertArticleViewModel.PublishedDate);

			ReflectivePropertyHelper.SetProperty(ReturnedArticle, "ArticleId", 100);			
		}

		internal IWriteArticles GetTarget()
		{
			EmployeeReader.Setup(x => x.GetByUsername(It.IsAny<string>()))
				.Returns(Author)
				.Verifiable();

			ArticleRepo.Setup(x => x.Insert(It.IsAny<Article>()))				
				.Callback((Article article) =>
				{
					ArticleCallbackResult = article;
				})
				.Returns(ReturnedArticle);

			ArticleRepo.Setup(x => x.Get(It.IsAny<Expression<Func<Article, bool>>>()))
				.Returns(new List<Article>
				{
					ReturnedArticle
				}.AsQueryable())
				.Callback(() =>
				{
					ArticleCallbackResult = ReturnedArticle;
				})
				.Verifiable();			

			return new ArticleWriter(ArticleViewModelValidator, EmployeeReader.Object, ArticleRepo.Object, UoW.Object);
		}

		internal IValidate<ArticleViewModel> ArticleViewModelValidator { get; set; }
		internal Mock<IReadEmployees> EmployeeReader { get; set; }
		internal Mock<IGenericRepository<Article>> ArticleRepo { get; set; }
		internal Mock<IUnitOfWork> UoW { get; set; }

		internal ArticleViewModelBuilder ArticleViewModelBuilder { get; set; }
		internal ArticleViewModel InsertArticleViewModel { get; set; }
		internal ArticleViewModel UpdateArticleViewModel { get; set; }
		internal Employee Author { get; set; }

		internal Article ReturnedArticle { get; set; }
		internal Article ArticleCallbackResult { get; set; }
	}
}