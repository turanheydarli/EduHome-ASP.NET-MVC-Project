﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class TeacherSkill : IEntity
	{
		public int Id { get; set; }
		public int Value { get; set; }
		public int TeacherId { get; set; }
		public int SkillId { get; set; }
	}
}
