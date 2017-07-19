using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
	public class ArticleViewModel
	{						
		[Required]
		[StringLength(255, ErrorMessage = "The {0} must be at max {1} characters long.")]
		[Display(Prompt = "Your article title...")]
		public string Title { get; set; }

		[Required]
		[StringLength(255, ErrorMessage = "The {0} must be at max {1} characters long.")]
		[Display(Prompt = "Your article summary...")]
		public string Summary { get; set; }

		[Required]
		[Display(
			Name="Article", 
			Prompt = "Your article...")]
		public string Body { get; set; }

		[Display(
			Name="Publish Date",
			Prompt = "dd/mm/yyyy hh:mm")]
		[DisplayFormat(DataFormatString = "dd/MM/yyyy HH:MM")]
		public DateTime? PublishedDate { get; set; }

		[Display(Name="Article Id")]
		public int ArticleId { get; set; }

		public int AuthorId { get; set; }
		public string Author { get; set; }
		public string AuthorUsername { get; set; }
		public int Likes { get; set; }
		public bool Liked { get; set; }
		
		public IEnumerable<string> ValidationErrors { get; set; }
	}
}