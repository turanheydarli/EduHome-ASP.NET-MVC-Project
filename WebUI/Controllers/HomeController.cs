using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ICourseService _courseService;

		public HomeController(ILogger<HomeController> logger, ICourseService courseService)
		{
			_logger = logger;
			_courseService = courseService;
		}

		public IActionResult Index()
		{
			return Content(_courseService.Add(
				new Course 
				{
					CategoryId = 1, Description = "awfw", ImagePath = "qfw", Price = 1131, Title = "aa1qgqege412421" 
				}
				).Message);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
