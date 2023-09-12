using System;
using System.Collections.Generic;

namespace CharityWork.Api.Models
{
    public partial class Visa
    {
        public decimal VisaId { get; set; }
        public string? OwnerName { get; set; }
        public string? OwnerEmail { get; set; }
        public decimal? Balance { get; set; }
        public string? Cardnumber { get; set; }
        public decimal? Cvv { get; set; }
        public DateTime? ExpDate { get; set; }
    }
}
