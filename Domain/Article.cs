using System;
using System.Collections.Generic;

namespace Domain
{
	public class Article
	{
		private Article() { }

		public Article(
			int authorId,
			string title,
			string summary,
			string body,
			DateTime? publishedDate
			)
		{
			AuthorId = authorId;
			Title = title;
			Summary = summary;
			Body = body;
			PublishedDate = publishedDate;

			CreatedDate = DateTime.UtcNow;			
		}

		public int ArticleId { get; private set; }
		public DateTime CreatedDate { get; private set; }
		public int AuthorId { get; private set; }
		public string Title { get; private set; }
		public string Summary { get; private set; }
		public string Body { get; private set; }
		public DateTime? PublishedDate { get; private set; }

		public virtual Employee Author { get; private set; }
		public virtual ICollection<ArticleLike> Likes { get; private set; }

		public void Update(int authorId, string title, string summary, string body, DateTime? publishedDate)
		{
			AuthorId = authorId;
			Title = title;
			Summary = summary;
			Body = body;
			PublishedDate = publishedDate;
		}
	}
}