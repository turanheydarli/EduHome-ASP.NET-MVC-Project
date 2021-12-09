using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewComponents
{
	public class SidebarCategoryViewComponent : ViewComponent
	{
		ICategoryService _categoryService;
		public SidebarCategoryViewComponent(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public IViewComponentResult Invoke()
		{
			return View(_categoryService.GetAllAsync().Result.Data); 
		}
	}
}
