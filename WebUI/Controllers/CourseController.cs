using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
	public class CourseController : Controller
	{
		ICourseService _courseService;
		public CourseController(ICourseService courseService)
		{
			_courseService = courseService;
		}

		public async Task<IActionResult> Index()
		{
			var courses = await _courseService.GetAllAsync();

			return View(courses.Data);
		}

		public IActionResult Detail(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var courseDetail = _courseService.GetCourseDetail((int)id);

			if(courseDetail.Data == null)
			{
				return NotFound();
			}

			return View(courseDetail.Data);
		}

	}
}
