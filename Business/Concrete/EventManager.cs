using Business.Abstract;
using Core.Extensions;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class EventManager : IEventService
	{
		IEventDal _eventDal;
		public EventManager(IEventDal eventDal)
		{
			_eventDal = eventDal;
		}

		public async Task<IResult> AddAsync(Event evnt)
		{

			string folder = Path.Combine(Environment.CurrentDirectory, "wwwroot", "assets", "img", "event");
			evnt.ImagePath = await evnt.Photo.SaveImageAsync(folder);

			_eventDal.Add(evnt);
			return new SuccessResult();
		}

		public IResult Delete(Event evnt)
		{
			_eventDal.Delete(evnt);
			return new SuccessResult();
		}

		public async Task<IDataResult<List<Event>>> GetAllAsync()
		{
			var result = await _eventDal.GetAllAsync();

			return new SuccessDataResult<List<Event>>(result);
		}

		public async Task<IDataResult<Event>> GetByIdAsync(int id)
		{
			var result = await _eventDal.GetAsync(e => e.Id == id);

			return new SuccessDataResult<Event>(result);
		}

		public IDataResult<EventDetailDto> GetEventDetail(int id)
		{
			var result = _eventDal.GetEventDetail(id);

			return new SuccessDataResult<EventDetailDto>(result);
		}

		public async Task<IResult> UpdateAsync(Event evnt)
		{
			var result = await _eventDal.GetAsync(e => e.Id == evnt.Id);

			evnt.ImagePath = result.ImagePath;
			evnt.Venue = "Baku";
			evnt.Date = result.Date;
			evnt.StartTime = DateTime.Now;
			evnt.EndTime = DateTime.Now.AddHours(4);

			if (evnt.Photo != null)
			{
				string folder = Path.Combine(Environment.CurrentDirectory, "wwwroot", "assets", "img", "event");
				evnt.ImagePath = await evnt.Photo.SaveImageAsync(folder);
			}

			_eventDal.Update(evnt);
			return new SuccessResult();
		}
	}
}
