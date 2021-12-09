using Core.Entities.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
	public class CourseDetailDto : IDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string ImagePath { get; set; }
		public decimal Price { get; set; }
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
		public int CourseDetailId { get; set; }
		public string Content { get; set; }
		public string AboutCourse { get; set; }
		public string HowToApply { get; set; }
		public string Certification { get; set; }
		public List<CourseParam> CourseParams { get; set; }
		public IFormFile Photo { get; set; }

	}
}
