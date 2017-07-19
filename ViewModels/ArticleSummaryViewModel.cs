using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
	public class ArticleSummaryViewModel
	{
		public int ArticleId { get; set; }
		public int AuthorId { get; set; }
		public string Title { get; set; }
		public string Summary { get; set; }
		public string Author { get; set; }
		public DateTime? PublishedDate { get; set; }
	}
}