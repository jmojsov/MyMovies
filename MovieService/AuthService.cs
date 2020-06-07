using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MyMovies.Data;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.DtoModels;
using MyMovies.Services.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyMovies.Services
{
    public class AuthService : IAuthService
    {
        public AuthService(IUserRepository usersRepo)
        {
            UsersRepo = usersRepo;
        }
        private IUserRepository UsersRepo { get; set; }

        public async Task<bool> SignInAsync(string username, string password, HttpContext httpContext)
        {
            var user = UsersRepo.GetByUsername(username);

            if (user != null && user.Password == password)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Username),
                    new Claim(ClaimTypes.Name, user.Username)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await httpContext.SignInAsync(principal);

                return true;
            }

            return false;
        }

        public async Task SignOutAsync(HttpContext httpContext)
        {
            await httpContext.SignOutAsync(); 
        }

        public SignUpResponse SignUp(string username, string password)
        {
            var user = UsersRepo.GetByUsername(username);
            var response = new SignUpResponse();

            if (user == null)
            {
                var newuser = new User();
                newuser.Username = user.Username;
                newuser.Password = user.Password;

                UsersRepo.Add(newuser);
                response.IsSuccessful = true;

                return response;
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = "User already exsists";
                return response;

            }
        }
    }
}
