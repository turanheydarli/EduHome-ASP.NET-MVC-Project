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
	public class CourseDetailManager : ICourseDetailService
	{
		ICourseDetailDal _courseDetailDal;

		public CourseDetailManager(ICourseDetailDal courseDetailDal)
		{
			_courseDetailDal = courseDetailDal;
		}

		public IResult Add(CourseDetail courseDetail)
		{
			_courseDetailDal.Add(courseDetail);
			return new SuccessResult();
		}

		public IResult Delete(CourseDetail courseDetail)
		{
			_courseDetailDal.Delete(courseDetail);
			return new SuccessResult("CourseDetail Added");
		}

		public async Task<IDataResult<CourseDetail>> GetByCourseIdAsync(int courseId)
		{
			var result = await _courseDetailDal.GetAsync(c => c.CourseId == courseId);

			return new SuccessDataResult<CourseDetail>(result);
		}

		public IResult Update(CourseDetail courseDetail)
		{
			_courseDetailDal.Update(courseDetail);
			return new SuccessResult();
		}
	}
}
