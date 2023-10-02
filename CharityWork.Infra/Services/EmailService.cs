using CharityWork.Core.Models;
using CharityWork.Core.Repository;
using CharityWork.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Infra.Services {
	public class EmailService : IEmailService {
		private readonly IEmailRepository _emailRepository;

		public EmailService(IEmailRepository emailRepository) {
			_emailRepository = emailRepository;
		}

		public void SendNormal(NormalEmail email) {
			_emailRepository.SendNormal(email);
		}

		public void SendPdfMail(AttachmentEmail attachment) {
			_emailRepository.SendPdfMail(attachment);
		}
	}
}
