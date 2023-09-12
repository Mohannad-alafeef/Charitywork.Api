using System;
using System.Collections.Generic;

namespace CharityWork.Api.Models
{
    public partial class Payment
    {
        public decimal PaymentId { get; set; }
        public string? PaymentType { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? Amount { get; set; }
        public decimal? UserId { get; set; }
        public decimal? CharityId { get; set; }

        public virtual Charity? Charity { get; set; }
        public virtual UserAccount? User { get; set; }
    }
}
