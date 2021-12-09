using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]

	public class EventController : Controller
	{
		IEventService _eventService;
		public EventController(IEventService eventService)
		{
			_eventService = eventService;
		}

		public async Task<IActionResult> Index()
		{
			var result = await _eventService.GetAllAsync();

			return View(result.Data);
		}

		#region Update
		public async Task<IActionResult> Update(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var eventToUpdate = await _eventService.GetByIdAsync((int)id);

			if(eventToUpdate == null)
			{
				return NotFound();
			}

			return View(eventToUpdate.Data);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public async Task<IActionResult> Update(int? id, Event evnt)
		{
			if (id == null)
			{
				return NotFound();
			}

			var eventToUpdate = await _eventService.GetByIdAsync((int)id);

			if (eventToUpdate == null)
			{
				return NotFound();
			}

			await _eventService.UpdateAsync(evnt);

			return RedirectToAction("Index");
		}
		#endregion

		#region Create

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Create(Event evnt)
		{
			evnt.Date = DateTime.Now;

			_eventService.AddAsync(evnt);

			return RedirectToAction("Index");
		}


		#endregion
	}
}
