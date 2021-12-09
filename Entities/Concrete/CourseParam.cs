using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class CourseParam : IEntity
	{
		public int Id { get; set; }
		public int CourseId { get; set; }
		public string ParamKey { get; set; }
		public string ParamValue { get; set; }
	}
}
