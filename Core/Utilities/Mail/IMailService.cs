using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Mail
{
	public interface IMailService
	{
		void Send(EmailMessage emailMessage);
	}
}
