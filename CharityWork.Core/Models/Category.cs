using System;
using System.Collections.Generic;

namespace CharityWork.Core.Models
{
    public partial class Testimonial
    {
        public Testimonial()
        {
            Charities = new HashSet<Charity>();
        }

        public decimal CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? ImagePath { get; set; }

        public virtual ICollection<Charity> Charities { get; set; }
    }
}
