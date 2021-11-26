using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface INoticeService
	{
		Task<IDataResult<List<Notice>>> GetAllAsync();
		Task<IDataResult<Notice>> GetByIdAsync(int id);
		IResult Add(Notice notice);
		IResult Delete(Notice notice);
		IResult Update(Notice notice);
	}
}
