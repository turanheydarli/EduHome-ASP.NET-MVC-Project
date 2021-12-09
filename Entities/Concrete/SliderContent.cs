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
	public class SliderContent:IEntity
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string ImagePath { get; set; }

		[NotMapped]
		public IFormFile Photo { get; set; }
	}
}
