using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Domain
{
	public class Employee
	{
		public Employee(
			string aspNetUserId, 
			string firstName,
			string lastName,
			int maxLikesPerMonth)
		{
			AspNetUserId = aspNetUserId;
			FirstName = firstName;
			LastName = lastName;
			MaxLikesPerMonth = maxLikesPerMonth;
		}

		public int EmployeeId { get; private set; }
		public string AspNetUserId { get; private set; }
		public string FirstName { get; private set; }
		public string LastName { get; private set; }
		public int MaxLikesPerMonth { get; private set; }

		public virtual ICollection<Article> Articles { get; private set; }		 
		public virtual ICollection<ArticleLike> ArticleLikes { get; private set; }
	}
}