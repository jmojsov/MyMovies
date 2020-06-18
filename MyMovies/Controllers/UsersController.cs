using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Custom;
using MyMovies.Helpers;
using MyMovies.Services;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;

namespace MyMovies.Controllers
{
    [Authorize(Policy = "IsAdmin")]

    public class UsersController : Controller
    {
        public UsersController(IUsersService usersService)
        {
            UsersService = usersService;
        }

        private IUsersService UsersService { get; }
        [Authorize(Policy ="IsAdmin")]
        public IActionResult ModifyUserOverview()
        {
            var modifyUserOverview = new List<ModifyUserOverviewModel> ();
            var users = UsersService.GetAll();
            foreach (var user in users)
            {
                modifyUserOverview.Add( ModelConvertor.ConvertToModifyUserOverview(user));
            }
            return View(modifyUserOverview);
        }
        public IActionResult ModifyUsersOverview()
        {
            var users = UsersService.GetAll();

            var viewModels = new List<ModifyUserOverviewModel>();
            foreach (var user in users)
            {
                viewModels.Add(ModelConvertor.ConvertToModifyUserOverview(user));
            }

            return View(viewModels);
        }


        public IActionResult Delete(int id)
        {
            if (!AuthorizeService.AuthorizeUser(User, id))
            {
                return RedirectToAction("Auth","AccessDenied");
            }

            UsersService.Delete(id);

            if (Convert.ToInt32(User.FindFirst("Id").Value) == id)
            {
                return RedirectToAction("Auth", "SignOut");
            }
            return RedirectToAction("UserModified");
        }
        public  IActionResult Modify(int id)
        {
            if (!AuthorizeService.AuthorizeUser(User, id))
            {
                return RedirectToAction("Auth", "AccessDenied");
            }

            var user = UsersService.GetById(id);

            var modifyUser = ModelConvertor.ConvertToUserModifyModel(user);

            return View(modifyUser);
        }
        [HttpPost]
        public IActionResult Modify(UserModifyModel userModifyModel)
        {
            if (ModelState.IsValid)
            {
                var user = ModelConvertor.ConvertFromUserModifyModel(userModifyModel);
                var result = UsersService.ModifyUser(user);

                if (result.Status)
                {
                    RedirectToAction("UserModified");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }

            return View(userModifyModel);

        }
        public IActionResult ChangePassword(int id)
        {
            if (!AuthorizeService.AuthorizeUser(User, id))
            {
                return RedirectToAction("Auth", "AccessDenied");
            }

            var model = new UserChangePassModel();
            model.Id = id;
            return View(model);
        }

        [HttpPost]
        public IActionResult ChangePassword(UserChangePassModel userChangePassModel)
        {
            if (!AuthorizeService.AuthorizeUser(User, userChangePassModel.Id))
            {
                return RedirectToAction("Auth", "AccessDenied");
            }

            if (ModelState.IsValid)
            {
                UsersService.ChangePassword(userChangePassModel.Id, userChangePassModel.Password);
                return RedirectToAction("UserModified");
            }

            return View(userChangePassModel);
        }

        [Authorize(Policy = "IsAdmin")]
        public IActionResult Create()
        {
            var user = new CreateUserModel();
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "IsAdmin")]
        public IActionResult Create(CreateUserModel createUserModel)
        {
            if (ModelState.IsValid)
            {
                var message = UsersService.CreateUser(createUserModel.Username, createUserModel.Password, createUserModel.IsAdmin);

                if (String.IsNullOrEmpty(message))
                {
                    return RedirectToAction("UserModified");
                }
                else
                {
                    ModelState.AddModelError("", message);
                }
            }

            return View(createUserModel);
        }

        public IActionResult Details(int id)
        {
            if (!AuthorizeService.AuthorizeUser(User, id))
            {
                return RedirectToAction("Auth", "AccessDenied");
            }

            var user = UsersService.GetById(id);
            var viewModel = ModelConvertor.ConvertToUserDetailsModel(user);
            return View(viewModel);
        }

        public IActionResult SuccessfulUserChange()
        {
            return View();
        }
    }
}