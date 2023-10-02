using CharityWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Repository {
	public interface IEmailRepository {

		void SendNormal(NormalEmail email);
		void SendPdfMail(AttachmentEmail attachment);
		string GenerateBody(string h1, string h2, string h3, string pAmount, Stream f);
		string GenerateStyle(Stream f);
	}
}
