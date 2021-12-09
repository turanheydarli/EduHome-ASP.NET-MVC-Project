using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
	public class EventDetailDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public string ImagePath { get; set; }
		public string Venue { get; set; }
		public DateTime Date { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public List<User> Speakers { get; set; }

	}
}
