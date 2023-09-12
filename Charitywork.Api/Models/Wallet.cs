using System;
using System.Collections.Generic;

namespace CharityWork.Api.Models
{
    public partial class Wallet
    {
        public decimal WalletId { get; set; }
        public decimal? Balance { get; set; }
        public string? Iban { get; set; }
        public decimal? UserId { get; set; }

        public virtual UserAccount? User { get; set; }
    }
}
