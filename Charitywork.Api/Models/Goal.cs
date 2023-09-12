using System;
using System.Collections.Generic;

namespace CharityWork.Api.Models
{
    public partial class Goal
    {
        public decimal GoalId { get; set; }
        public string? GoalText { get; set; }
        public decimal? CharityId { get; set; }

        public virtual Charity? Charity { get; set; }
    }
}
