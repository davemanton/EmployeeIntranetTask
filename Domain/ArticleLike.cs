using System;

namespace Domain
{
	public class ArticleLike
	{
		public ArticleLike(
			int articleId,
			int employeeId
			)
		{
			ArticleId = articleId;
			EmployeeId = employeeId;
			
			CreatedDate = DateTime.UtcNow;
		}

		public int ArticleId { get; private set; }
		public int EmployeeId { get; private set; }
		public DateTime CreatedDate { get; private set; }

		public virtual Article Article { get; private set; }
		public virtual Employee Employee { get; private set; }
	}
}