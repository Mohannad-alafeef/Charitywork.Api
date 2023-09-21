using System;
using System.Collections.Generic;

namespace CharityWork.Core.Models
{
    public partial class UserAccount
    {
        public UserAccount()
        {
            Charities = new HashSet<Charity>();
            IssuesReports = new HashSet<IssuesReport>();
            Payments = new HashSet<Payment>();
            Testimonials = new HashSet<Testimonial>();
           VisaCards = new HashSet<VisaCard>();
        }

        public decimal UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public decimal? Age { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public DateTime? LoginDate { get; set; }
        public string? ImagePath { get; set; }
        public decimal? LoginId { get; set; }

        public virtual UserLogin? Login { get; set; }
        public virtual VisaCard? VisaCard { get; set; }

        public virtual ICollection<Charity> Charities { get; set; }
        public virtual ICollection<IssuesReport> IssuesReports { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
        public virtual ICollection<VisaCard> VisaCards { get; set; }
    }
}
