using System;
using Application.Employees;
using DataAccess.Context;
using DataAccess.Repository;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

		internal Employee CallbackEmployee { get; set; }

	}

	[TestClass]
	public class EmployeeWriterTests
	{
		[TestMethod]
		public void Create_ShouldInsertAndSaveEmployee()
		{
			var wrapper = new EmployeeWriterTestWrapper();

			var target = wrapper.GetTarget();

			var response = target.Create(wrapper.UserName, wrapper.FirstName, wrapper.LastName);

			Assert.IsNotNull(response);		

			wrapper.EmployeeRepo.Verify(x => x.Insert(It.IsAny<Employee>()));
			wrapper.UnitOfWork.Verify(x => x.Save());
		}

		[TestMethod]
		public void Create_ShouldReturnNullIfExceptionThrown_AndNotThrowException()
		{
			var wrapper = new EmployeeWriterTestWrapper();

			var target = wrapper.GetTarget();

			wrapper.UnitOfWork.Setup(x => x.Save()).Throws(new Exception());

			Employee response = new Employee(wrapper.UserName, wrapper.FirstName, wrapper.LastName, wrapper.MaxNoLikes);
			try
			{
				response = target.Create(wrapper.UserName, wrapper.FirstName, wrapper.LastName);
			}
			catch
			{
				Assert.Fail("Exception thrown");
			}

			Assert.IsNull(response);
		}
	}
}