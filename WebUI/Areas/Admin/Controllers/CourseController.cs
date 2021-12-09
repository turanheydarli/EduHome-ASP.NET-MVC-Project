using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	[Area("Admin")]
	public class CourseController : Controller
	{
		ICourseService _courseService;
		ICategoryService _categoryService;
		ICourseDetailService _courseDetailService;
		public CourseController(ICourseService courseService, 
			ICategoryService categoryService, ICourseDetailService courseDetailService)
		{
			_courseService = courseService;
			_categoryService = categoryService;
			_courseDetailService = courseDetailService;

		}
		public async Task<IActionResult> Index()
		{
			var courses = await _courseService.GetAllAsync();

			return View(courses.Data);
		}

		#region Update
		public async Task<IActionResult> Update(int? id)
		{
			if(id == null)
			{
				return NotFound();
			}

			var courseToUpdate = _courseService.GetCourseDetail((int)id);

			ViewBag.Categories = (await _categoryService.GetAllAsync()).Data;

			if (courseToUpdate.Data == null)
			{
				return NotFound();
			}

			return View(courseToUpdate.Data);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(int? id, CourseDetailDto courseDetailDto)
		{
			if (id == null)
			{
				return NotFound();
			}

			var courseToUpdate = _courseService.GetCourseDetail((int)id);

			ViewBag.Categories = (await _categoryService.GetAllAsync()).Data;

			if (courseToUpdate.Data == null)
			{
				return NotFound();
			}

			Course course = new Course
			{
				Id = courseToUpdate.Data.Id,
				CategoryId = courseDetailDto.CategoryId,
				Description = courseDetailDto.Description,
				Title = courseDetailDto.Title,
				ImagePath = courseDetailDto.ImagePath,
				Price = courseDetailDto.Price,
				Photo = courseDetailDto.Photo
			};

			CourseDetail courseDetail = new CourseDetail
			{
				Id = courseToUpdate.Data.CourseDetailId,
				CourseId = courseDetailDto.Id,
				AboutCourse = courseDetailDto.AboutCourse,
				Content = courseDetailDto.Content,
				HowToApply = courseDetailDto.HowToApply,
				Certification = courseDetailDto.Certification,
			};

			await _courseService.UpdateAsync(course);

			_courseDetailService.Update(courseDetail);

			return RedirectToAction("Index");
		}

		#endregion

		#region Create
		public async Task<IActionResult> Create()
		{
			ViewBag.Categories = (await _categoryService.GetAllAsync()).Data;

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public async Task<IActionResult> Create(CourseDetailDto courseDetailDto)
		{
			ViewBag.Categories = (await _categoryService.GetAllAsync()).Data;

			Course course = new Course
			{
				CategoryId = courseDetailDto.CategoryId,
				Description = courseDetailDto.Description,
				Title = courseDetailDto.Title,
				ImagePath = courseDetailDto.ImagePath,
				Price = courseDetailDto.Price,
				Photo = courseDetailDto.Photo
			};

			await _courseService.AddAsync(course);

			var addedCourse = (await _courseService.GetAllAsync()).Data.LastOrDefault();

			CourseDetail courseDetail = new CourseDetail
			{
				CourseId = addedCourse.Id,
				AboutCourse = courseDetailDto.AboutCourse,
				Content = courseDetailDto.Content,
				HowToApply = courseDetailDto.HowToApply,
				Certification = courseDetailDto.Certification,
			};

			_courseDetailService.Add(courseDetail);
			

			return View(courseDetailDto);
		}
		#endregion

		#region Delete
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var courseToDelete = await _courseService.GetByIdAsync((int)id);

			if (courseToDelete.Data == null) 
			{
				return NotFound();
			}

			return View(courseToDelete.Data);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[ActionName("Delete")]
		public async Task<IActionResult> DeletePost(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var courseToDelete = await _courseService.GetByIdAsync((int)id);

			var courseDetailToDelete = await _courseDetailService.GetByCourseIdAsync((int)id);

			if (courseToDelete.Data == null)
			{
				return NotFound();
			}

			_courseDetailService.Delete(courseDetailToDelete.Data);

			_courseService.Delete(courseToDelete.Data);

			return RedirectToAction("Index");
		}
		#endregion
	}
}
