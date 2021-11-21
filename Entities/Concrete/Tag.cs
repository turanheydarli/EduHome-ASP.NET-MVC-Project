﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Tag : IEntity
	{
		public int Id { get; set; }
		public int? CourseId { get; set; }
		public int? BlogId { get; set; }
		public string Name { get; set; }
	}
}
