using System;
using System.Collections.Generic;

namespace CharityWork.Api.Models
{
    public partial class Role
    {
        public Role()
        {
            UserLogins = new HashSet<UserLogin>();
        }

        public string? RoleName { get; set; }
        public decimal RoleId { get; set; }

        public virtual ICollection<UserLogin> UserLogins { get; set; }
    }
}
