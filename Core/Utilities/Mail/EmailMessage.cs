﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Mail
{
	public class EmailMessage
	{
		public EmailMessage()
		{
			ToAddresses = new List<EmailAdress>();
			FromAddresses = new List<EmailAdress>();
		}

		public List<EmailAdress> ToAddresses { get; set; }
		public List<EmailAdress> FromAddresses { get; set; }
		public string Subject { get; set; }
		public string Content { get; set; }
	}
}
