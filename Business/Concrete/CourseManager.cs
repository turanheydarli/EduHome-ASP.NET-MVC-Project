using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Extensions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
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
		public async Task<IResult> AddAsync(Course course)
		{
			string folder = Path.Combine(Environment.CurrentDirectory, "wwwroot", "assets", "img", "course");

			course.ImagePath = await course.Photo.SaveImageAsync(folder);

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

		public IDataResult<CourseDetailDto> GetCourseDetail(int id)
		{
			var result = _courseDal.GetCourseDetail(id);

			return new SuccessDataResult<CourseDetailDto>(result);
		}

		public async Task<IDataResult<List<Course>>> SearchAsync(string query)
		{
			var result = await _courseDal.GetAllAsync(c => c.Title.Contains(query));

			return new SuccessDataResult<List<Course>>(result);
		}

		[ValidationAspect(typeof(CourseValidator))]
		public async Task<IResult> UpdateAsync(Course course)
		{
			string folder = Path.Combine(Environment.CurrentDirectory, "wwwroot", "assets", "img", "course");

			var courseToUpdate = await _courseDal.GetAsync(c => c.Id == course.Id);

			course.ImagePath = courseToUpdate.ImagePath;

			if (course.Photo != null)
			{
				course.ImagePath = await course.Photo.SaveImageAsync(folder);
			}

			_courseDal.Update(course);
			return new SuccessResult();
		}
	}
}
