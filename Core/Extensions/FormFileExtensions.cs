using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
	public static class FormFileExtensions
	{ 
		public static bool IsImage(this IFormFile formFile)
		{
			return formFile.ContentType.Contains("image/");
		}

		public static async Task<string> SaveImageAsync(this IFormFile formFile, string folder)
		{
			string fileName = Guid.NewGuid().ToString() + "-image." + formFile.ContentType.Split("/")[1];
			string fullPath = Path.Combine(folder, fileName);

			using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
			{
				await formFile.CopyToAsync(fileStream);
			}

			return fileName;
		}

	}
}
