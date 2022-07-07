using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineMenu.Core.Entities;
using OnlineMenu.UI.ViewModels;

namespace OnlineMenu.UI.Controllers
{
    public class UserController : Controller
    {

        private readonly UserManager<User> _userManager;
        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> SignUp(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = new();
                user.Email = userViewModel.Email;   
                user.PhoneNumber = userViewModel.PhoneNumber;
                user.UserName = userViewModel.UserName;
                IdentityResult result = await _userManager.CreateAsync(user, userViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("LogIn");
                }
                else
                {
                    foreach (IdentityError item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }

            return View(userViewModel);
        }


    }
}
