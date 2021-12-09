using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCourseDal : EfEntityRepositoryBase<Course, EduHomeContext>, ICourseDal
	{
		public CourseDetailDto GetCourseDetail(int id)
		{
			using (EduHomeContext context = new EduHomeContext())
			{
				var result = from course in context.Courses
							 where course.Id == id
							 join courseDetail in context.CourseDetails on course.Id equals courseDetail.CourseId
							 join courseParam in context.CourseParams on course.Id equals courseParam.CourseId
							 join category in context.Categories on course.CategoryId equals category.Id
							 select new CourseDetailDto
							 {
								 Id = course.Id,
								 Title = course.Title,
								 Description = course.Description,
								 ImagePath = course.ImagePath,
								 Price = course.Price,
								 CategoryId = category.Id,
								 CategoryName = category.Name,
								 Content = courseDetail.Content,
								 AboutCourse = courseDetail.AboutCourse,
								 HowToApply = courseDetail.HowToApply,
								 Certification = courseDetail.Certification,
								 CourseDetailId = courseDetail.Id,
								 CourseParams = new List<CourseParam> { courseParam },
							 };

				return result.FirstOrDefault();
			}
		}
	}
}
