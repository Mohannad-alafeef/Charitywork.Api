using System;
using System.Collections.Generic;

namespace CharityWork.Api.Models
{
    public partial class Testimonial
    {
        public decimal TestimonialId { get; set; }
        public string? Content { get; set; }
        public decimal? Rate { get; set; }
        public DateTime? TestimonialDate { get; set; }
        public decimal? UserId { get; set; }
        public decimal? IsAccepted { get; set; }

        public virtual UserAccount? User { get; set; }
    }
}
