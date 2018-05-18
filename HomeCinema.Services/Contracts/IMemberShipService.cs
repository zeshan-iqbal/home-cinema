using HomeCinema.Core.Domain;
using HomeCinema.Services.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Services.Contracts
{
    public interface IMembershipService
    {
        Task<MembershipContext> ValidateUserAsync(string username, string password);
        Task<User> CreateUserAsync(string username, string email, string password, int[] roles);
        Task<User> GetUserAsync(int userId);
        Task<List<Role>> GetUserRolesAsync(string username);
    }
}
