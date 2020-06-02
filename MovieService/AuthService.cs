﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
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
    }
}
