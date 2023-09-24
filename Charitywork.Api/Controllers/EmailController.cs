using CharityWork.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace CharityWork.Api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class EmailController : ControllerBase {

		[HttpPost("sendNormal")]
		public async Task<IActionResult> SendEmail(NormalEmail email) {
			try {
				using (MailMessage mailMessage = new MailMessage()) {
					mailMessage.From = new MailAddress("eng.mohannad.alafeef@gmail.com");
					mailMessage.Subject = email.Subject;
					mailMessage.Body = email.Body;


					mailMessage.To.Add(new MailAddress(email.ReciverEmail));
					SmtpClient smtp = new SmtpClient();
					smtp.Host = "smtp.gmail.com";
					smtp.EnableSsl = true;
					NetworkCredential NetworkCred = new NetworkCredential();
					NetworkCred.UserName = "eng.mohannad.alafeef@gmail.com";
					NetworkCred.Password = "ukjaaxxcvakneyzl";
					smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
					smtp.UseDefaultCredentials = false;
					smtp.Credentials = NetworkCred;
					smtp.Port = 587;
					await smtp.SendMailAsync(mailMessage);
				}
			return Ok();
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
			

		}
	}
}
