using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineMenu.Core.Entities;
using OnlineMenu.UI.ViewModels;

namespace OnlineMenu.UI.Controllers
{
    public class UserController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel loginViewModel )
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByEmailAsync(loginViewModel.Email);
                if (user!=null)
                {
                    await _signInManager.SignOutAsync();
                   Microsoft.AspNetCore.Identity.SignInResult result= await _signInManager.PasswordSignInAsync(user,loginViewModel.Password,false,false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Deneme");
                    }
                


                }
                else
                {
                    ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifresi");
                }
            }
            return View();
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
