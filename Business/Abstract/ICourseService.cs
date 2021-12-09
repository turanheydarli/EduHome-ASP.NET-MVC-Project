using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ICourseService
	{
		Task<IResult> AddAsync(Course course);
		Task<IResult> UpdateAsync(Course course);
		IResult Delete(Course course);
		Task<IDataResult<List<Course>>> GetAllAsync();
		Task<IDataResult<List<Course>>> SearchAsync(string query);
		Task<IDataResult<Course>> GetByIdAsync(int id);
		IDataResult<CourseDetailDto> GetCourseDetail(int id);

	}
}
