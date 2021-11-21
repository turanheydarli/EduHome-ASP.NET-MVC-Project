using Entities.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
	public class CourseValidator : AbstractValidator<Course>
	{
		public CourseValidator()
		{
			RuleFor(c => c.Description).NotEmpty();
			RuleFor(c => c.Description).MinimumLength(10);
			RuleFor(c => c.Price).NotEmpty();
			RuleFor(c => c.Price).GreaterThan(0);
			RuleFor(c => c.Title).NotEmpty();
			RuleFor(c => c.Title).MinimumLength(5);
			RuleFor(c => c.CategoryId).NotNull();
		}
	}
}
