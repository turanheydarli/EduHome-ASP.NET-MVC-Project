using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class TeacherManager : ITeacherService
	{
		
		public IResult Add(Teacher teacher)
		{
			throw new NotImplementedException();
		}

		public Task<IDataResult<Teacher>> GetByEmailAsync(string email)
		{
			throw new NotImplementedException();
		}
	}
}
