using System;
using System.Collections.Generic;

namespace CharityWork.Api.Models
{
    public partial class Category
    {
        public Category()
        {
            Charities = new HashSet<Charity>();
        }

        public decimal CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? ImagePath { get; set; }

        public virtual ICollection<Charity> Charities { get; set; }
    }
}
