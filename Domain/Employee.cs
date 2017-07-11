using System.Collections.Generic;

namespace Domain
{
	public class Employee
	{
		private Employee() { }

		public Employee(
			string username, 
			string firstName,
			string lastName,
			int maxLikesPerMonth)
		{
			Username = username;
			FirstName = firstName;
			LastName = lastName;
			MaxLikesPerMonth = maxLikesPerMonth;
		}

		public int EmployeeId { get; private set; }
		public string Username { get; private set; }
		public string FirstName { get; private set; }
		public string LastName { get; private set; }
		public int MaxLikesPerMonth { get; private set; }

		public virtual ICollection<Article> Articles { get; private set; }		 
		public virtual ICollection<ArticleLike> ArticleLikes { get; private set; }
	}
}