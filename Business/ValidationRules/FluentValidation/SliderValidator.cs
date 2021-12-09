using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
	public class SliderValidator : AbstractValidator<SliderContent>
	{
		public SliderValidator()
		{
			RuleFor(x => x.Photo).NotEmpty();
		}
	}
}
