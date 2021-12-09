using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfEventDal : EfEntityRepositoryBase<Event, EduHomeContext>, IEventDal
	{
		public EventDetailDto GetEventDetail(int id)
		{
			using (EduHomeContext context = new EduHomeContext())
			{
				var result = from evnt in context.Events
							 where evnt.Id == id
							 join eventUser in context.EventUsers on evnt.Id equals eventUser.EventId 
							 select new EventDetailDto
							 {
								 Id = evnt.Id,
								 Content = evnt.Content,
								 Date = evnt.Date,
								 EndTime = evnt.EndTime,
								 StartTime = evnt.StartTime,
								 ImagePath = evnt.ImagePath,
								 Speakers = context.Users.Where(u => u.Id == eventUser.UserId).ToList(),
								 Title = evnt.Title,
								 Venue = evnt.Venue
							 };

				return result.FirstOrDefault();
			}
		}
	}
}
