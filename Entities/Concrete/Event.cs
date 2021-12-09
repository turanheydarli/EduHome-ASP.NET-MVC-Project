using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Event : IEntity
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public string ImagePath { get; set; }
		public string Venue { get; set; }
		public DateTime Date { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		[NotMapped]
		public IFormFile Photo { get; set; }
	}
}
