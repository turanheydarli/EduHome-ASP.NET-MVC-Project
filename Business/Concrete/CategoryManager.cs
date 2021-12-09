using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class CategoryManager : ICategoryService
	{
		ICategoryDal _categoryDal;
		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}

		public IResult Add(Category category)
		{
			_categoryDal.Add(category);
			return new SuccessResult();
		}

		public IResult Delete(Category category)
		{
			_categoryDal.Delete(category);
			return new SuccessResult("Category Added");
		}

		public async Task<IDataResult<List<Category>>> GetAllAsync()
		{
			var result = await _categoryDal.GetAllAsync();

			return new SuccessDataResult<List<Category>>(result);
		}

		public async Task<IDataResult<Category>> GetByIdAsync(int id)
		{
			var result = await _categoryDal.GetAsync(s => s.Id == id);

			return new SuccessDataResult<Category>(result);
		}

		public IResult Update(Category category)
		{
			_categoryDal.Update(category);
			return new SuccessResult();
		}
	}
}
