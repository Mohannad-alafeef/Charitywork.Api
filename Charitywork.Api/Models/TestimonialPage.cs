using System;
using System.Collections.Generic;

namespace CharityWork.Api.Models
{
    public partial class TestimonialPage
    {
        public decimal TestimonialId { get; set; }
        public string? Title { get; set; }
        public string? ImagePath { get; set; }
        public string? Text { get; set; }
        public decimal? HomeId { get; set; }

        public virtual HomePage? Home { get; set; }
    }
}
