using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewModels
{
	public class HomeViewModel
	{
		public List<SliderContent> SliderContents { get; set; }
		public List<Notice> Notices { get; set; }
		public List<Course> Courses { get; set; }
		public List<Blog> Blogs { get; set; }
	}
}
