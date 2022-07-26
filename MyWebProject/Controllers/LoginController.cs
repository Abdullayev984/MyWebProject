using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebProject.BLL.Services.IServices;

using MyWebProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MyWebProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        public readonly IUserService _userService;
      
        public LoginController(IUserService userService)
        {
            _userService = userService;
            
        }
       

     
        public async Task<IActionResult> ToLogin(UserToListDTO user)
        {
            List<UserToListDTO> users =await _userService.Get();
            var dataValue = users.FirstOrDefault(m => m.UserName == user.UserName && m.UserPassword == user.UserPassword);
            if (dataValue != null)
            {
                //var claims = new List<Claim>
                //{
                //new Claim(ClaimTypes.Name,user.UserName)
                //};
                //var identity = new ClaimsIdentity(claims, "Login");
                //ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                //await HttpContext.SignInAsync(principal);
               
                return RedirectToAction("Index", "Department");

            }
            ViewBag.Message = "error";
            return View();

        }
     
        public async Task< IActionResult> ChangePassword(UserToAddorUpdateDTO user)
        {
           
            List<UserToListDTO> users = await _userService.Get();
            foreach (var item in users)
            {
                if(user.UserName == item.UserName)
                {
                    if (user.UserPassword == user.ConfirmPassword)
                    {
                        await _userService.Delete(item.UserName);
                      await _userService.Add(user);
                 
                        return RedirectToAction("ToLogin", "Login");
                    }


                }
               
                
            }
            return View();
        }
        public async Task<IActionResult>LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("ToLogin");
        }
    }

}
