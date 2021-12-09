using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Extensions;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
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

		[ValidationAspect(typeof(SliderValidator))]
		public async Task<IResult> AddAsync(SliderContent sliderContent)
		{
			BusinessRules.Run(CheckSliderImage(sliderContent));

			string folder = Path.Combine(Environment.CurrentDirectory, "wwwroot", "assets", "img", "slider");

			sliderContent.ImagePath = await sliderContent.Photo.SaveImageAsync(folder);

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

		public async Task<IResult> UpdateAsync(SliderContent sliderContent)
		{
			string folder = Path.Combine(Environment.CurrentDirectory, "wwwroot", "assets", "img", "slider");

			var sliderToUpdate = await _sliderContentDal.GetAsync(s => s.Id == sliderContent.Id);

			sliderContent.ImagePath = sliderToUpdate.ImagePath;

			if(sliderContent.Photo != null)
			{
				sliderContent.ImagePath = await sliderContent.Photo.SaveImageAsync(folder);
			}
			
			_sliderContentDal.Update(sliderContent);

			if (File.Exists(folder + sliderToUpdate.ImagePath))
			{
				File.Delete(folder + sliderToUpdate.ImagePath);
			}

			return new SuccessResult("Slider guncellendi");
		}

		private IResult CheckSliderImage(SliderContent sliderContent)
		{
			if (!sliderContent.Photo.IsImage())
			{
				return new ErrorResult("Please select image");
			}

			return new SuccessResult();
		}
	}
}
