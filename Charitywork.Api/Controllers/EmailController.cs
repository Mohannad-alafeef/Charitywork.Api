using Azure.Core.Pipeline;
using CharityWork.Core.Models;
using CharityWork.Core.Services;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.pipeline.html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;


namespace CharityWork.Api.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class EmailController : ControllerBase {
		private readonly IEmailService _emailService;

		public EmailController(IEmailService emailService) {
			_emailService = emailService;
		}

		[HttpPost("sendNormal")]
		public async Task<IActionResult> SendEmail(NormalEmail email) {
			try {
				_emailService.SendNormal(email);
			return Ok();
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
			

		}
		[HttpPost("sendWithPdf")]
		public async Task<IActionResult> SendWithPdf([FromForm]AttachmentEmail email) {
			
			try {
				 _emailService.SendPdfMail(email);

				return Ok();
			}
			catch (Exception ex) {
				return BadRequest(ex.Message);
			}
		}
	}
}
