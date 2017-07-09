using Domain;

namespace Application.Employees
{
	public interface IWriteEmployees
	{
		Employee Create(string username, string firstName, string lastName, int maxLikesPerMonth = 5);
	}
}