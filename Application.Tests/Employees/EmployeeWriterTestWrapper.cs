using Application.Employees;
using DataAccess.Repository;
using Domain;
using Moq;

namespace Application.Tests.Employees
{
	internal class EmployeeWriterTestWrapper
	{
		internal EmployeeWriterTestWrapper()
		{
			EmployeeRepo = new Mock<IGenericRepository<Employee>>();
			UnitOfWork = new Mock<IUnitOfWork>();

			UserName = "Username";
			FirstName = "FirstName";
			LastName = "LastName";
			MaxNoLikes = 5;
		}

		internal IWriteEmployees GetTarget()
		{
			EmployeeRepo.Setup(x => x.Insert(It.IsAny<Employee>()))
				.Returns(new Employee(UserName, FirstName, LastName, MaxNoLikes))
				.Verifiable();

			return new EmployeeWriter(EmployeeRepo.Object, UnitOfWork.Object);
		}

		internal Mock<IGenericRepository<Employee>> EmployeeRepo { get; set; }
		internal Mock<IUnitOfWork> UnitOfWork { get; set; }

		internal string UserName { get; set; }
		internal string FirstName { get; set; }
		internal string LastName { get; set; }
		internal int MaxNoLikes { get; set; }
	}
}