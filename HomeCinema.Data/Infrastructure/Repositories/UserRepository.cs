using HomeCinema.Core.Domain;
using HomeCinema.Data.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HomeCinema.Data.Infrastructure.Repositories
{
    public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        public UserRepository(IHomeCinemaDbContext context) : base(context)
        {
        }

        public async Task<User> GetSingleByUsernameAsync(string username)
        {
            return await Entities
                        .Where(user => user.Username == username)
                        .Include(user => user.UserRoles)
                        .FirstOrDefaultAsync();
        }
    }
}
