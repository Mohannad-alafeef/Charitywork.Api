using System;
using System.Collections.Generic;

namespace CharityWork.Api.Models
{
    public partial class Contact
    {
        public decimal ContactId { get; set; }
        public string? SenderName { get; set; }
        public string? SenderEmail { get; set; }
        public string? ContactSubject { get; set; }
        public string? ContactContent { get; set; }
        public decimal? ContactStatus { get; set; }
    }
}
