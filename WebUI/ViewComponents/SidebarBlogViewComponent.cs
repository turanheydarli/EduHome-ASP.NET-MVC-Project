using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewComponents
{
	public class SidebarBlogViewComponent : ViewComponent
	{
		IBlogService _blogService;
		public SidebarBlogViewComponent(IBlogService blogService)
		{
			_blogService = blogService;
		}

		public IViewComponentResult Invoke()
		{
			var result = _blogService.GetAllAsync();

			return View(result.Result.Data);
		}
	}
}
