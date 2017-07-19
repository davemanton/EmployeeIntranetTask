using Domain;
using TestLibrary.ViewModelBuilders;
using ViewModels;

namespace TestLibrary.DomainBuilder
{
	public class EmployeeBuilder
	{
		public Employee Object { get; private set; }

		public EmployeeBuilder Build()
		{
			Object = new Employee
			(
				"Username",
				"FirstName",
				"LastName",
				5
			);

			return this;
		}
	}
}