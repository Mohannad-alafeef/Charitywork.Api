using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Models {
	public class AttachmentEmail {
		public string? ReciverEmail { get; set; }
		public string? Subject { get; set; }
		public string? Body { get; set; }
		public string? PTitle { get; set; }
		public string? PBody { get; set; }
		public string? PCharity { get; set; }
		public string? PAmount { get; set; }
		public IFormFile? PTemplate { get; set; }
		public IFormFile? PStyle { get; set; }
	}
}
