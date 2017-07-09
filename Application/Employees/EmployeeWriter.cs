using DataAccess.Repository;
using Domain;

namespace Application.Employees
{
	public class EmployeeWriter : IWriteEmployees
	{
		private readonly IGenericRepository<Employee> _employeeRepo;
		private readonly IUnitOfWork _uow;

		public EmployeeWriter(
			IGenericRepository<Employee> employeeRepo, 
			IUnitOfWork uow)
		{
			_employeeRepo = employeeRepo;
			_uow = uow;
		}

		public Employee Create(string username, string firstName, string lastName, int maxLikesPerMonth = 5)
		{
			var employee = new Employee(username, firstName, lastName, maxLikesPerMonth);

			try
			{
				employee = _employeeRepo.Insert(employee);

				_uow.Save();
			}
			catch
			{
				return null;
			}

			return employee;
		}
	}
}