using CharityWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Services {
	public interface IEmailService {
		void SendNormal(NormalEmail email);
		void SendPdfMail(AttachmentEmail attachment);
	}
}
