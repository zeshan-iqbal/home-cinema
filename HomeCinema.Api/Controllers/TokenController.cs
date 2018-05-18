using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeCinema.Core.Domain;
using HomeCinema.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HomeCinema.Api.Controllers
{    
    [Route("api/Token")]
    public class TokenController : Controller
    {
        private readonly IConfiguration config;
        private readonly IMembershipService membershipService;

        public TokenController(IConfiguration config, IMembershipService membershipService)
        {
            this.config = config;
            this.membershipService = membershipService;
        }

        public async Task<IActionResult> Post(LoginModel loginModel)
        {
            var response = Unauthorized();

            var membershipContext = await membershipService.ValidateUserAsync(loginModel.Username, loginModel.Password);
            if(membershipContext != null)
            {
                var tokenString = BuildToke(membershipContext.User);
            }

            return response;
        }

        private string BuildToke(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            throw new NotImplementedException();
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}