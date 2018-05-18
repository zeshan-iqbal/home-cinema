using HomeCinema.Core.Domain;
using HomeCinema.Data.Infrastructure.Contracts;
using HomeCinema.Services.Contracts;
using HomeCinema.Services.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Services.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IUserRoleRepository userRoleRepository;
        private readonly IEncryptionService encryptionService;
        private readonly IHomeCinemaUnitOfWork unitOfWork;

        public MembershipService(IHomeCinemaUnitOfWork unitOfWork, IEncryptionService encryptionService)
        {
            this.userRepository = unitOfWork.UserRepository;
            this.roleRepository = unitOfWork.RoleRepository;
            this.userRoleRepository = unitOfWork.UserRoleRepository;
            this.encryptionService = encryptionService;
            this.unitOfWork = unitOfWork;
        }

        public async Task<User> CreateUserAsync(string username, string email, string password, int[] roles)
        {
            var user = await userRepository.GetSingleByUsernameAsync(username);

            if (user != null) throw new Exception("Username is already in use");

            user = new User()
            {
                Username = username,
                Email = email,
                HashedPassword = encryptionService.EncryptPassword(password),
                IsLocked = false
            };

            userRepository.Add(user);

            await unitOfWork.CommitAsync();

            foreach (var role in roles)
            {
                AddUserToRole(user, role);
            }

            await unitOfWork.CommitAsync();

            return user;
        }

        public async Task<User> GetUserAsync(int userId)
        {
            return await userRepository.GetSingleAsync(userId);
        }

        public async Task<List<Role>> GetUserRolesAsync(string username)
        {
            var roles = new List<Role>();

            var user = await userRepository.GetSingleByUsernameAsync(username);

            if (user != null)
            {
                foreach (var userRole in user.UserRoles)
                {
                    roles.Add(userRole.Role);
                }
            }

            return roles;
        }

        public async Task<MembershipContext> ValidateUserAsync(string username, string password)
        {
            var memberShipContext = new MembershipContext();
            var user = await userRepository.GetSingleByUsernameAsync(username);

            if(user != null & IsUserValid(user, password))
            {
                var userRoles = await GetUserRolesAsync(username);
                memberShipContext.User = user;

                var identity = new GenericIdentity(user.Username);
                memberShipContext.Principal = new GenericPrincipal(
                    identity,
                    userRoles.Select(userRole => userRole.Name).ToArray());
            }

            return memberShipContext;
        }

        #region Helper Methods
        private void AddUserToRole(User user, int roleId)
        {
            var role = roleRepository.GetSingle(roleId);
            if (role == null)
                throw new ApplicationException("Role doesn't exist.");

            var userRole = new UserRole()
            {
                RoleId = role.Id,
                UserId = user.Id
            };

            userRoleRepository.Add(userRole);
        }

        private bool IsPasswordValid(User user, string password)
        {
            return string.Equals(encryptionService.EncryptPassword(password), user.HashedPassword);
        }

        private bool IsUserValid(User user, string password)
        {
            if (IsPasswordValid(user, password))
            {
                return !user.IsLocked;
            }

            return false;
        }
        #endregion
    }
}
