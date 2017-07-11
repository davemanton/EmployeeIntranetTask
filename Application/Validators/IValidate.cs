using System;
using System.Collections.Generic;

namespace Application.Validators
{
	public interface IValidate<in T> where T : class
	{		
		bool Validate(T viewModel, out IEnumerable<string> validationErrors);
	}
}