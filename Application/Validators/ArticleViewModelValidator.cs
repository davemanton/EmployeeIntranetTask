using System.Collections.Generic;
using System.Linq;
using ViewModels;

namespace Application.Validators
{
	public class ArticleViewModelValidator : IValidate<ArticleViewModel>
	{
		public bool Validate(ArticleViewModel viewModel, out IEnumerable<string> validationErrors)
		{
			validationErrors = Validate(viewModel);

			return validationErrors.Any();
		}

		private static IEnumerable<string> Validate(ArticleViewModel viewModel)
		{
			if (string.IsNullOrWhiteSpace(viewModel.AuthorUsername)) yield return "Article must have an author";
			if (string.IsNullOrWhiteSpace(viewModel.Title)) yield return "Article must have a title";
			if (string.IsNullOrWhiteSpace(viewModel.Summary)) yield return "Article must have a summary";
			if (string.IsNullOrWhiteSpace(viewModel.Body)) yield return "Article must have a body";
		}
	}
}