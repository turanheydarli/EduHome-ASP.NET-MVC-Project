using Core.Utilities.Results;
using Entities.Concrete;
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
		IResult Add(SliderContent sliderContent);
		IResult Delete(SliderContent sliderContent);
		IResult Update(SliderContent sliderContent);
	}
}
