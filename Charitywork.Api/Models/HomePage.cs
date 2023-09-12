using System;
using System.Collections.Generic;

namespace CharityWork.Api.Models
{
    public partial class HomePage
    {
        public HomePage()
        {
            AboutUsPages = new HashSet<AboutUsPage>();
            ContactUsPages = new HashSet<ContactUsPage>();
            TestimonialPages = new HashSet<TestimonialPage>();
        }

        public decimal HomeId { get; set; }
        public string? Title { get; set; }
        public string? ImagePath { get; set; }
        public string? Text { get; set; }

        public virtual ICollection<AboutUsPage> AboutUsPages { get; set; }
        public virtual ICollection<ContactUsPage> ContactUsPages { get; set; }
        public virtual ICollection<TestimonialPage> TestimonialPages { get; set; }
    }
}
