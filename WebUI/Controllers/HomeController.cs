using Business.Abstract;
using Core.Utilities.Mail;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
	public class HomeController : Controller
	{
		private readonly IUserService _userService;
		private readonly IAuthService _authService;
		private readonly INoticeService _noticeService;
		private readonly ICourseService _courseService;
		private readonly ISliderContentService _sliderContentService;
		private readonly IBlogService _blogService;
		private readonly IConfiguration _configuration;

		public HomeController(
			IUserService userService, IAuthService authService,
			ISliderContentService sliderContentService, INoticeService noticeService,
			ICourseService courseService, IBlogService blogService, IConfiguration configuration)
		{
			_userService = userService;
			_authService = authService;
			_sliderContentService = sliderContentService;
			_noticeService = noticeService;
			_courseService = courseService;
			_blogService = blogService;
			_configuration = configuration;
		}

		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Index()
		{
			var sliderContents = await _sliderContentService.GetAllAsync();
			var notices = await _noticeService.GetAllAsync();
			var courses = await _courseService.GetAllAsync();
			var blogs = await _blogService.GetAllAsync();

			HomeViewModel viewModel = new HomeViewModel
			{
				SliderContents = sliderContents.Data,
				Notices = notices.Data,
				Courses = courses.Data.OrderByDescending(x => x.Id).Take(3).ToList(),
				Blogs = blogs.Data.OrderByDescending(x => x.Id).Take(3).ToList(),
			};


			return View(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Search(string query)
		{
			SearchViewModel viewModel = new SearchViewModel
			{
				Courses = (await _courseService.SearchAsync(query)).Data,
			};

			return View(viewModel);
		}

	}
}
