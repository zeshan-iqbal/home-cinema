using HomeCinema.Core.Domain;
using HomeCinema.Data.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCinema.Data.Infrastructure.Repositories
{
    public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        public UserRepository(IHomeCinemaDbContext context) : base(context)
        {
        }
    }
}
