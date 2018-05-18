using HomeCinema.Core.Domain;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace HomeCinema.Services.Utils
{
    public class MembershipContext
    {
        public IPrincipal Principal { get; set; }
        public User User { get; set; }

        public bool IsValid()
        {
            return Principal != null;
        }
    }
}
