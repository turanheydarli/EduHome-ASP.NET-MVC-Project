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
			optionsBuilder.UseSqlServer("Server=.;Database=EduHome;Trusted_Connection=true");
		}
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<OperationClaim> OperationClaims { get; set; }
		public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
		public DbSet<SliderContent> SliderContents { get; set; }
		public DbSet<Notice> Notices { get; set; }
	}
}
