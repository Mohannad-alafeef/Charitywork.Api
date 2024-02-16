using CharityWork.Core.Models;
using CharityWork.Core.Repository;
using System.Net.Mail;
using System.Net;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml.pipeline.html;
using iTextSharp.tool.xml.html;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.pipeline.end;
using iTextSharp.tool.xml.parser;


namespace CharityWork.Infra.Repository {
	public class EmailRepository : IEmailRepository {
		public string GenerateBody(string pTitle, string pBody, string pCharity,string pAmount, Stream f) {
			string body = string.Empty;


			using (StreamReader reader = new StreamReader(f)) {
				body = reader.ReadToEnd();
			}

			body = body.Replace("{Header1}", pTitle);
			body = body.Replace("{body}", pBody);
			body = body.Replace("{charity}", pCharity);
			body = body.Replace("{amount}", pAmount);
			body = body.Replace("{date}", DateTime.Now.ToString());
			return body;
		}

		public string GenerateStyle(Stream f) {
			string style = string.Empty;
			using (StreamReader reader = new StreamReader(f)) {
				style = reader.ReadToEnd();
			}
			return style;
		}

		public async void SendNormal(NormalEmail email) {
			using (MailMessage mailMessage = new MailMessage()) {
				mailMessage.From = new MailAddress("****@gmail.com");
				mailMessage.Subject = email.Subject;
				mailMessage.Body = email.Body;


				mailMessage.To.Add(new MailAddress(email.ReciverEmail));
				SmtpClient smtp = new SmtpClient();
				smtp.Host = "smtp.gmail.com";
				smtp.EnableSsl = true;
				NetworkCredential NetworkCred = new NetworkCredential();
				NetworkCred.UserName = "****@gmail.com";
				NetworkCred.Password = "*************";
				smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
				smtp.UseDefaultCredentials = false;
				smtp.Credentials = NetworkCred;
				smtp.Port = 587;
				await smtp.SendMailAsync(mailMessage);
			}
		}

		public async void SendPdfMail(AttachmentEmail attachment) {
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			using (MailMessage mailMessage = new MailMessage()) {
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				byte[]? bytesArray = null;
				using (var ms = new MemoryStream()) {
					var document = new Document();
					PdfWriter writer = PdfWriter.GetInstance(document, ms);
					document.Open();
					var htmlBody = GenerateBody(attachment.PTitle, attachment.PBody, attachment.PCharity,attachment.PAmount, attachment.PTemplate.OpenReadStream());
					var cssBody = GenerateStyle(attachment.PStyle.OpenReadStream());
					using (var strReader = new StringReader(htmlBody)) {
						//Set factories
						HtmlPipelineContext htmlContext = new HtmlPipelineContext(null);
						htmlContext.SetTagFactory(Tags.GetHtmlTagProcessorFactory());
						//Set css
						ICSSResolver cssResolver = XMLWorkerHelper.GetInstance().GetDefaultCssResolver(false);
						//string contentRootPath1 = wwwRoot + "/PdfForm/test.html";
						cssResolver.AddCss(cssBody, true);
						//Export
						IPipeline pipeline = new CssResolverPipeline(cssResolver, new HtmlPipeline(htmlContext, new PdfWriterPipeline(document, writer)));
						var worker = new XMLWorker(pipeline, true);
						var xmlParse = new XMLParser(true, worker);
						xmlParse.Parse(strReader);
						xmlParse.Flush();
					}
					document.Close();
					bytesArray = ms.ToArray();
				}
				mailMessage.From = new MailAddress("*****@gmail.com");
				mailMessage.Subject = attachment.Subject;
				mailMessage.Body = attachment.Body;
				mailMessage.IsBodyHtml = true;
				mailMessage.Attachments.Add(new Attachment(new MemoryStream(bytesArray), "payment receipt.pdf"));

				mailMessage.To.Add(new MailAddress(attachment.ReciverEmail));
				SmtpClient smtp = new SmtpClient();
				smtp.Host = "smtp.gmail.com";
				smtp.EnableSsl = true;
				NetworkCredential NetworkCred = new NetworkCredential();
				NetworkCred.UserName = "*****@gmail.com";
				NetworkCred.Password = "*************";
				smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
				smtp.UseDefaultCredentials = false;
				smtp.Credentials = NetworkCred;
				smtp.Port = 587;
				await smtp.SendMailAsync(mailMessage);
			}
		}
	}
}
