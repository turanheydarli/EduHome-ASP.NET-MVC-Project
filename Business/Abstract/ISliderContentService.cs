using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ISliderContentService
	{
		Task<IDataResult<List<SliderContent>>> GetAllAsync();
		Task<IDataResult<SliderContent>> GetByIdAsync(int id);
		Task<IResult> AddAsync(SliderContent sliderContent);
		IResult Delete(SliderContent sliderContent);
		Task<IResult> UpdateAsync(SliderContent sliderContent);
	}
}
