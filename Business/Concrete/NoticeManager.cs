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
	public class NoticeManager : INoticeService
	{
		INoticeDal _noticeDal;
		public NoticeManager(INoticeDal noticeDal)
		{
			_noticeDal = noticeDal;
		}

		public IResult Add(Notice notice)
		{
			_noticeDal.Add(notice);
			return new SuccessResult("notice əlavə edildi");
		}

		public IResult Delete(Notice notice)
		{
			_noticeDal.Delete(notice);
			return new SuccessResult("notice silindi");
		}

		public async Task<IDataResult<List<Notice>>> GetAllAsync()
		{
			var result = await _noticeDal.GetAllAsync();

			return new SuccessDataResult<List<Notice>>(result);
		}

		public async Task<IDataResult<Notice>> GetByIdAsync(int id)
		{
			var result = await _noticeDal.GetAsync(s => s.Id == id);

			return new SuccessDataResult<Notice>(result);
		}

		public IResult Update(Notice notice)
		{
			_noticeDal.Update(notice);
			return new SuccessResult("Slider guncellendi");
		}
	}
}
