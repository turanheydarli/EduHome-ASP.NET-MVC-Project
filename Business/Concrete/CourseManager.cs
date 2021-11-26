using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
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
	public class CourseManager : ICourseService
	{
		ICourseDal _courseDal;
		public CourseManager(ICourseDal courseDal)
		{
			_courseDal = courseDal;
		}

		[ValidationAspect(typeof(CourseValidator))]
		public IResult Add(Course course)
		{
			_courseDal.Add(course);
			return new SuccessResult();
		}

		public IResult Delete(Course course)
		{
			_courseDal.Delete(course);
			return new SuccessResult("Course Added");
		}

		public async Task<IDataResult<List<Course>>> GetAllAsync()
		{
			var result = await _courseDal.GetAllAsync();

			return new SuccessDataResult<List<Course>>(result);
		}

		public async Task<IDataResult<Course>> GetByIdAsync(int id)
		{
			var result = await _courseDal.GetAsync(s => s.Id == id);

			return new SuccessDataResult<Course>(result);
		}

		public IResult Update(Course course)
		{
			_courseDal.Update(course);
			return new SuccessResult();
		}
	}
}
