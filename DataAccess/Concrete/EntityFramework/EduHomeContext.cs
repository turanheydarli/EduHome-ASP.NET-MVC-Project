using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EduHomeContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=.;Database=EduHome;Integrated Security=SSPI");
		}
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<CourseDetail> CourseDetails { get; set; }
		public DbSet<CourseParam> CourseParams { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<OperationClaim> OperationClaims { get; set; }
		public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
		public DbSet<SliderContent> SliderContents { get; set; }
		public DbSet<Notice> Notices { get; set; }
		public DbSet<Event> Events { get; set; }
		public DbSet<EventUser> EventUsers { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<TeacherDetail> TeacherDetails { get; set; }
		public DbSet<TeacherSkill> TeacherSkills { get; set; }
		public DbSet<Skill> Skills { get; set; }
	}
}
