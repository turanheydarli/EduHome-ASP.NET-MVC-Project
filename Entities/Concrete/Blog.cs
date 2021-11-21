using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Blog : IEntity
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string ImagePath { get; set; }
		public DateTime Date { get; set; }
		public int UserID { get; set; }

	}
}
