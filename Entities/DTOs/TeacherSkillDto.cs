using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
	public class TeacherSkillDto:IDto
	{
		public string Skill { get; set; }
		public int Value { get; set; }
	}
}
