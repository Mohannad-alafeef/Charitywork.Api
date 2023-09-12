using System;
using System.Collections.Generic;

namespace CharityWork.Core.Models
{
    public partial class Charity
    {
        public Charity()
        {
            Goals = new HashSet<Goal>();
            Payments = new HashSet<Payment>();
        }

        public decimal CharityId { get; set; }
        public string? Longitude { get; set; }
        public string? Latitude { get; set; }
        public string? Mission { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? ImagePath { get; set; }
        public decimal? UserId { get; set; }
        public decimal? CategoryId { get; set; }
        public decimal? IsAccepted { get; set; }
        public string? CharityName { get; set; }
        public decimal? DonationGoal { get; set; }

        public virtual Category? Category { get; set; }
        public virtual UserAccount? User { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
