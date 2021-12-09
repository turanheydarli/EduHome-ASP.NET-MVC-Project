using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IEventService
	{
		Task<IDataResult<List<Event>>> GetAllAsync();
		Task<IDataResult<Event>> GetByIdAsync(int id);
		IDataResult<EventDetailDto> GetEventDetail(int id);
		Task<IResult> AddAsync(Event evnt);
		IResult Delete(Event evnt);
		Task<IResult> UpdateAsync(Event evnt);
	}
}
