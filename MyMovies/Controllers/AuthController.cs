using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;

namespace MyMovies.Controllers
{
    public class AuthController : Controller
    {
        public AuthController(IAuthService authService)
        {
            AuthService = authService;
        }

        private IAuthService AuthService { get; set; }

        public IActionResult SignIn()
        {
            var signInModel = new SignInModel();
            return View(signInModel);
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            if (ModelState.IsValid)
            {
                var isSignedIn = await AuthService.SignInAsync(model.Username, model.Password, HttpContext);
                if (isSignedIn)
                {
                    return RedirectToAction("Overview", "Movies");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Username or password is incorrect");
                    return View(model);
                }
            }

            return View(model);

        }
    }
    
}