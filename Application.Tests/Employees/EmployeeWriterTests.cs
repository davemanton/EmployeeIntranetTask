using System;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Application.Tests.Employees
{
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

			// To ensure response is not already null
			var response = new Employee(wrapper.UserName, wrapper.FirstName, wrapper.LastName, wrapper.MaxNoLikes);

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