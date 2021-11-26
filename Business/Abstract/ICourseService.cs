using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ICourseService
	{
		IResult Add(Course course);
		IResult Update(Course course);
		IResult Delete(Course course);
		Task<IDataResult<List<Course>>> GetAllAsync();
		Task<IDataResult<Course>> GetByIdAsync(int id);

	}
}
