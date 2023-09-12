using System;
using System.Collections.Generic;

namespace CharityWork.Api.Models
{
    public partial class UserLogin
    {
        public UserLogin()
        {
            UserAccounts = new HashSet<UserAccount>();
        }

        public decimal LoginId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public decimal? RoleId { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }
}
