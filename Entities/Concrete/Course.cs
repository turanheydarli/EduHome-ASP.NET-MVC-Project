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
	public class Course: IEntity
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string ImagePath { get; set; }
		public decimal Price { get; set; }
		public int CategoryId { get; set; }

		[NotMapped]
		public IFormFile Photo { get; set; }
	}
}
