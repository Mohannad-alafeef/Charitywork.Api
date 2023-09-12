using System;
using System.Collections.Generic;

namespace CharityWork.Core.Models
{
    public partial class VisaCard
    {
        public decimal VisaId { get; set; }
        public decimal? Balance { get; set; }
        public string? CardNumber { get; set; }
        public decimal? Cvv { get; set; }
        public DateTime? ExpDate { get; set; }
        public decimal? UserId { get; set; }

        public virtual UserAccount? User { get; set; }
    }
}
