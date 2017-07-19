using Domain;

namespace Application.Employees
{
	public interface IReadEmployees
	{
		Employee GetByUsername(string username, bool includeLikes = false);
	}
}