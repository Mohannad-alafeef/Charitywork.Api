using System;
using System.Collections.Generic;

namespace CharityWork.Api.Models
{
    public partial class ContactUsPage
    {
        public decimal ContactId { get; set; }
        public string? Title { get; set; }
        public string? EmailAddress { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? OpenHours { get; set; }
        public decimal? HomeId { get; set; }

        public virtual HomePage? Home { get; set; }
    }
}
