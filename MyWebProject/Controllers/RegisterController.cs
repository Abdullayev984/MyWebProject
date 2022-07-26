using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebProject.BLL.Services.IServices;

using MyWebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebProject.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {

        public readonly IUserService _userService;

        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult ToRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ToRegister(UserToAddorUpdateDTO user)
        {
            try
            {
                if (user.UserPassword == user.ConfirmPassword)
                {
                    await _userService.Add(user);

                    return RedirectToAction("ToLogin", "Login");
                }
                else
                {
                    ViewBag.dgr = "password don't match";
                    return View();
                }
            }
            catch (Exception)
            {

                return View();
            }
           
                   
                   
                }
            //    else
            //    {
            //        return View();
            //    }
            //}
            //return View();
        }
    }
//}}
           
            
           
       // }
    //}

