using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfTeacherDal : EfEntityRepositoryBase<Teacher, EduHomeContext>, ITeacherDal
	{
		public TeacherDetailDto GetDetailById(int id)
		{
			using (EduHomeContext context = new EduHomeContext())
			{
				var result = from teacher in context.Teachers
							 where teacher.Id == id
							 join teacherDetail in context.TeacherDetails on teacher.Id equals teacherDetail.TeacherId
							 select new TeacherDetailDto
							 {
								 Id = teacher.Id,
								 FullName = $"{teacher.LastName} {teacher.FirstName}",
								 ImagePath = teacher.ImagePath,
								 Status = teacher.Status,
								 AboutMe = teacherDetail.AboutMe,
								 Degree = teacherDetail.Degree,
								 Email = teacherDetail.Email,
								 Experience = teacherDetail.Experience,
								 Facebook = teacherDetail.Facebook,
								 Faculty = teacherDetail.Faculty,
								 Hobbies = teacherDetail.Hobbies,
								 Phone = teacherDetail.Phone,
								 Position = teacherDetail.Position,
								 Twitter = teacherDetail.Twitter
							 };
				return result.FirstOrDefault();
			}
		}

		public List<TeacherSkillDto> GetSkillsByTeacherId(int teacherId)
		{
			using (EduHomeContext context = new EduHomeContext())
			{
				var result = from teacherSkill in context.TeacherSkills
							 where teacherId == teacherSkill.TeacherId
							 join skill in context.Skills on teacherSkill.SkillId equals skill.Id
							 select new TeacherSkillDto
							 {
								 Skill = skill.Content,
								 Value = teacherSkill.Value
							 };

				return result.ToList();
			}
		}
	}
}
