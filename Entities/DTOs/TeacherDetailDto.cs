﻿using Core.Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
	public class TeacherDetailDto : IDto
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string ImagePath { get; set; }
		public bool Status { get; set; }
		public string AboutMe { get; set; }
		public string Degree { get; set; }
		public string Experience { get; set; }
		public string Hobbies { get; set; }
		public string Faculty { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string Facebook { get; set; }
		public string Twitter { get; set; }
		public string Position { get; set; }
	}
}
