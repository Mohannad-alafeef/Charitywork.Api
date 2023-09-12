using System;
using System.Collections.Generic;

namespace CharityWork.Api.Models
{
    public partial class ProblemReport
    {
        public decimal ProblemId { get; set; }
        public DateTime? ReportDate { get; set; }
        public string? Message { get; set; }
        public decimal? UserId { get; set; }

        public virtual UserAccount? User { get; set; }
    }
}
