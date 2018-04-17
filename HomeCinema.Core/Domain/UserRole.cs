using HomeCinema.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Core.Domain
{
    public class UserRole : BaseEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
