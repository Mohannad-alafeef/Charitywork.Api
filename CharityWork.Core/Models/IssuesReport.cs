﻿using System;
using System.Collections.Generic;

namespace CharityWork.Core.Models
{
    public partial class IssuesReport
    {
        public decimal ProblemId { get; set; }
        public DateTime? ReportDate { get; set; }
        public string? Message { get; set; }
        public decimal? UserId { get; set; }
        public string? Subject { get; set; }
        public decimal? IssueStatus { get; set; }

        public virtual UserAccount? User { get; set; }
    }
}
