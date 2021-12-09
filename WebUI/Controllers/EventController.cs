using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
	public class EventController : Controller
	{
		IEventService _eventService;
		public EventController(IEventService eventService)
		{
			_eventService = eventService;
		}

		public async Task<IActionResult> Index()
		{
			var events = await _eventService.GetAllAsync();

			return View(events.Data);
		}

		public IActionResult Detail(int? id)
		{
			if(id == null)
			{
				return NotFound();
			}

			var result = _eventService.GetEventDetail((int)id);

			if(result.Data == null)
			{
				return NotFound();
			}

			return View(result.Data);
		}
	}
}
