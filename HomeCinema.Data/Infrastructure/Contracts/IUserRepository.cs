using HomeCinema.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Infrastructure.Contracts
{
    public interface IUserRepository : IEntityBaseRepository<User>
    {
        Task<User> GetSingleByUsernameAsync(string username);
    }
}
