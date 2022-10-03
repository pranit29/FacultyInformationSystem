using FacultyInformationSystem.Models;
using FacultyInformationSystem.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FacultyInformationSystem.Controllers
{
    public class UserLoginController : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(User model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = UserLogic.SignUpUser(model.UserId, model.Email, model.Password, model.UserType);

                if (recordsCreated == 1)
                {
                    return RedirectToAction("SignIn");
                }
            }

            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(User model)
        {
            var data = UserLogic.SignInUser(model.UserId, model.Email, model.Password, model.UserType);


            if (data == null)
            {
                return LocalRedirect("~/");
            }
            else
            {
                List<User> obj = new List<User>();

                foreach (var row in data)
                {
                    obj.Add(new User
                    {
                        UserId = row.UserId,
                        Email = row.Email,
                        Password = row.Password,
                        UserType = row.UserType
                    });
                }
                
                
                    int response = obj[0].UserType;

                    if (response == 1)
                    {
                        return RedirectToAction("AdminLogin");
                    }
                    else if (response == 2)
                    {
                        return RedirectToAction("FacultyLogin");
                    }

                    return View();
                }
            }
        

        public IActionResult AdminLogin()
        {
            return View();
        }

        public IActionResult FacultyLogin()
        {
            return View();
        }

    }
}
