using Business.Abstract;
using Core.Extensions;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	[Area("Admin")]
	public class SliderController : Controller
	{
		ISliderContentService _sliderContentService;
		public SliderController(ISliderContentService sliderContentService)
		{
			_sliderContentService = sliderContentService;
		}

		public async Task<IActionResult> Index()
		{
			var sliderContents = await _sliderContentService.GetAllAsync();

			return View(sliderContents.Data);
		}

		public async Task<IActionResult> Detail(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var sliderContent = await _sliderContentService.GetByIdAsync((int)id);

			if (sliderContent.Data == null)
			{
				return NotFound();
			}

			return View(sliderContent.Data);
		}

		#region Update
		public async Task<IActionResult> Update(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var sliderContent = await _sliderContentService.GetByIdAsync((int)id);

			if (sliderContent.Data == null)
			{
				return NotFound();
			}

			return View(sliderContent.Data);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(SliderContent sliderContent, IFormFile formFile)
		{
			if (sliderContent == null)
			{
				return NotFound();
			}

			await _sliderContentService.UpdateAsync(sliderContent);

			return RedirectToAction("Index");
		}
		#endregion

		#region Delete
		public async Task<IActionResult> Delete(int? id)
		{
			if(id == null)
			{
				return NotFound();
			}

			var slider = await _sliderContentService.GetByIdAsync((int)id);

			if(slider == null)
			{
				return NotFound();
			}

			return View(slider.Data);
		}

		[HttpPost]
		[ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeletePost(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var slider = await _sliderContentService.GetByIdAsync((int)id);

			if (slider == null)
			{
				return NotFound();
			}

			_sliderContentService.Delete(slider.Data);

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
		public async Task<IActionResult> Create(SliderContent sliderContent, IFormFile formFile)
		{

			await _sliderContentService.AddAsync(sliderContent);

			return RedirectToAction("Index");
		}

		#endregion
	}
}
