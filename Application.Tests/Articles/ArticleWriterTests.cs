using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ViewModels;

namespace Application.Tests.Articles
{
	[TestClass]
	public class ArticleWriterTests
	{
		[TestMethod]
		public void Create_IfInputIsNull_ShouldReturnNull()
		{
			var wrapper = new ArticleWriterTestWrapper();

			var target = wrapper.GetTarget();

			var response = target.Create(null);

			Assert.IsNull(response);
		}

		[TestMethod]
		public void Create_ShouldValidate_AndReturnVmWithErrors()
		{
			var wrapper = new ArticleWriterTestWrapper();

			var target = wrapper.GetTarget();

			var response = target.Create(new ArticleViewModel());

			Assert.IsTrue(response.ValidationErrors.Any());
		}

		[TestMethod]
		public void Create_ShouldInsertArticle_WithCorrectAuthorId()
		{
			var wrapper = new ArticleWriterTestWrapper();

			var target = wrapper.GetTarget();

			var response = target.Create(wrapper.InsertArticleViewModel);			

			Assert.AreEqual(wrapper.InsertArticleViewModel.Title, wrapper.ArticleCallbackResult.Title);
			Assert.AreEqual(wrapper.InsertArticleViewModel.Summary, wrapper.ArticleCallbackResult.Summary);
			Assert.AreEqual(wrapper.InsertArticleViewModel.Body, wrapper.ArticleCallbackResult.Body);
			Assert.AreEqual(wrapper.InsertArticleViewModel.PublishedDate, wrapper.ArticleCallbackResult.PublishedDate);

			Assert.AreEqual(wrapper.Author.EmployeeId, wrapper.ArticleCallbackResult.AuthorId);

			wrapper.ArticleRepo.Verify(x => x.Insert(It.IsAny<Article>()), Times.Once);
			wrapper.UoW.Verify(x => x.Save(), Times.Once);
		}

		[TestMethod]
		public void Create_ShouldReturnArticleId_InArticleViewModel()
		{
			var wrapper = new ArticleWriterTestWrapper();

			var target = wrapper.GetTarget();

			var response = target.Create(wrapper.InsertArticleViewModel);

			Assert.AreEqual(wrapper.ReturnedArticle.ArticleId, response.ArticleId);
			Assert.IsTrue(response.ArticleId != default(int));
		}

		[TestMethod]
		public void Create_ShouldReturnNullIfExceptionThrown_AndNotThrowException()
		{
			var wrapper = new ArticleWriterTestWrapper();

			var target = wrapper.GetTarget();

			wrapper.UoW.Setup(x => x.Save()).Throws(new Exception());

			// To ensure response is not already null
			var response = new ArticleViewModel();

			try
			{
				response = target.Create(wrapper.InsertArticleViewModel);
			}
			catch
			{
				Assert.Fail("Exception thrown");
			}

			Assert.IsNull(response);
		}

		[TestMethod]
		public void Update_IfInputIsNull_ShouldReturnNull()
		{
			var wrapper = new ArticleWriterTestWrapper();

			var target = wrapper.GetTarget();

			var response = target.Update(null);

			Assert.IsNull(response);
		}

		[TestMethod]
		public void Update_ShouldValidate_AndReturnVmWithErrors()
		{
			var wrapper = new ArticleWriterTestWrapper();

			var target = wrapper.GetTarget();

			var response = target.Update(new ArticleViewModel());

			Assert.IsTrue(response.ValidationErrors.Any());
		}

		[TestMethod]
		public void Update_ShouldRetrieveArticleWithSameId_AndUpdateProperties_ThenSave()
		{
			var wrapper = new ArticleWriterTestWrapper();

			var target = wrapper.GetTarget();

			var response = target.Update(wrapper.UpdateArticleViewModel);

			Assert.AreEqual(wrapper.UpdateArticleViewModel.Title, wrapper.ArticleCallbackResult.Title);
			Assert.AreEqual(wrapper.UpdateArticleViewModel.Summary, wrapper.ArticleCallbackResult.Summary);
			Assert.AreEqual(wrapper.UpdateArticleViewModel.Body, wrapper.ArticleCallbackResult.Body);
			Assert.AreEqual(wrapper.UpdateArticleViewModel.PublishedDate, wrapper.ArticleCallbackResult.PublishedDate);
		}

		[TestMethod]
		public void Update_ShouldReturnNullIfExceptionThrown_AndNotThrowException()
		{
			var wrapper = new ArticleWriterTestWrapper();

			var target = wrapper.GetTarget();

			wrapper.UoW.Setup(x => x.Save()).Throws(new Exception());

			// To ensure response is not already null
			var response = new ArticleViewModel();

			try
			{
				response = target.Update(wrapper.UpdateArticleViewModel);				
			}
			catch
			{
				Assert.Fail("Exception thrown");
			}

			Assert.IsNull(response);
		}

		[TestMethod]
		public void Update_ShouldCreate_IfOriginalArticleNotFound()
		{
			var wrapper = new ArticleWriterTestWrapper();

			var target = wrapper.GetTarget();

			wrapper.ArticleRepo.Setup(x => x.Get(It.IsAny<Expression<Func<Article, bool>>>()))
				.Returns(new List<Article>().AsQueryable());

			target.Update(wrapper.UpdateArticleViewModel);
			
			wrapper.ArticleRepo.Verify(x => x.Insert(It.IsAny<Article>()), Times.Once);
		}
	}
}