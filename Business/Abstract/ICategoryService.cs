using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ICategoryService
	{
		Task<IDataResult<List<Category>>> GetAllAsync();
		Task<IDataResult<Category>> GetByIdAsync(int id);
		IResult Add(Category category);
		IResult Delete(Category category);
		IResult Update(Category category);
	}
}
