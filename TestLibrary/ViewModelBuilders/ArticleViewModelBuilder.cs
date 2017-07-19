using System;
using ViewModels;

namespace TestLibrary.ViewModelBuilders
{
	public class ArticleViewModelBuilder
	{
		public ArticleViewModel Object { get; private set; }

		public ArticleViewModelBuilder BuildNew()
		{
			Object = new ArticleViewModel
			{
				AuthorUsername = "AuthorUsername",
				Title = "Title",
				Summary = "Summary",
				Body = "Body",
				PublishedDate = new DateTime(2017, 1, 25)
			};

			return this;
		}

		public ArticleViewModelBuilder BuildUpdate()
		{
			Object = new ArticleViewModel
			{
				ArticleId = 100,
				AuthorUsername = "AuthorUsername",
				Title = "TitleToUpdate",
				Summary = "SummaryToUpdate",
				Body = "BodyToUpdate",
				PublishedDate = new DateTime(2017, 10, 25)
			};

			return this;
		}
	}
}