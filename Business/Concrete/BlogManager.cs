using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class BlogManager:IBlogService
	{
		IBlogDal _blogDal;
		public BlogManager(IBlogDal blogDal)
		{
			_blogDal = blogDal;
		}

		public IResult Add(Blog blog)
		{
			_blogDal.Add(blog);
			return new SuccessResult();
		}

		public IResult Delete(Blog blog)
		{
			_blogDal.Delete(blog);
			return new SuccessResult("Blog Added");
		}

		public async Task<IDataResult<List<Blog>>> GetAllAsync()
		{
			var result = await _blogDal.GetAllAsync();

			return new SuccessDataResult<List<Blog>>(result);
		}

		public async Task<IDataResult<Blog>> GetByIdAsync(int id)
		{
			var result = await _blogDal.GetAsync(s => s.Id == id);

			return new SuccessDataResult<Blog>(result);
		}

		public IResult Update(Blog blog)
		{
			_blogDal.Update(blog);
			return new SuccessResult();
		}
	}
}
