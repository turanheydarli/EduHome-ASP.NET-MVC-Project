using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class CourseDetail : IEntity
	{
		public int Id { get; set; }
		public int CourseId { get; set; }
		public string Content { get; set; }
		public string AboutCourse { get; set; }
		public string HowToApply { get; set; }
		public string Sertification { get; set; }
	}
}
