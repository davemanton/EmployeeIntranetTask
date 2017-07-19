using System;
using System.Dynamic;
using System.Linq;
using Domain;
using DataAccess.Repository;

namespace Application.Employees
{
	
	public class EmployeeReader : IReadEmployees
	{
		private readonly IGenericRepository<Employee> _employeeRepo;

		public EmployeeReader(IGenericRepository<Employee> employeeRepo)
		{
			_employeeRepo = employeeRepo;
		}

		public Employee GetByUsername(string username, bool includeLikes = false)
		{
			if(includeLikes)
				return _employeeRepo.Get(
					x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase),
					x => x.ArticleLikes
					)?.SingleOrDefault();

			return _employeeRepo.Get(x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase))?.SingleOrDefault();
		}
	}
}