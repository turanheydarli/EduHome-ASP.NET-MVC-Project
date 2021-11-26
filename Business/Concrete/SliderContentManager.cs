using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class SliderContentManager : ISliderContentService
	{
		ISliderContentDal _sliderContentDal;
		public SliderContentManager(ISliderContentDal sliderContentDal)
		{
			_sliderContentDal = sliderContentDal;
		}

		public IResult Add(SliderContent sliderContent)
		{
			_sliderContentDal.Add(sliderContent);
			return new SuccessResult("Slider əlavə edildi");
		}

		public IResult Delete(SliderContent sliderContent)
		{
			_sliderContentDal.Delete(sliderContent);
			return new SuccessResult("Slider silindi");
		}

		public async Task<IDataResult<List<SliderContent>>> GetAllAsync()
		{
			var result = await _sliderContentDal.GetAllAsync();

			return new SuccessDataResult<List<SliderContent>>(result);
		}

		public async Task<IDataResult<SliderContent>> GetByIdAsync(int id)
		{
			var result = await _sliderContentDal.GetAsync(s => s.Id == id);

			return new SuccessDataResult<SliderContent>(result);
		}

		public IResult Update(SliderContent sliderContent)
		{
			_sliderContentDal.Update(sliderContent);
			return new SuccessResult("Slider guncellendi");
		}
	}
}
