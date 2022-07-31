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

        public IActionResult LogIn(string returnUrl)//authorize bir controllera erişmek istediğimiz zaamaan cookie içerisinde belirlenen login path a bir return url döndürür
        {
            TempData["ReturnUrl"]= returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel loginViewModel )
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByEmailAsync(loginViewModel.Email);//dogukan.matul@gmail.com
                
               
                if (user!=null)
                {

                    if (await _userManager.IsLockedOutAsync(user))
                    {
                        ModelState.AddModelError("", "Hesabınız Bir süreliğine kilitlenmiştir lütfen daha sonra tekrar deneyiniz.");

                        return View(loginViewModel);
                    }



                    await _signInManager.SignOutAsync();
                   Microsoft.AspNetCore.Identity.SignInResult result= await _signInManager.PasswordSignInAsync(user,loginViewModel.Password, loginViewModel.RememberMe,false);

                    if (result.Succeeded)
                    {
                        await _userManager.ResetAccessFailedCountAsync(user);
                        if (TempData["ReturnUrl"]!=null)
                        {
                            return Redirect(TempData["ReturnUrl"].ToString());
                        }
                        return RedirectToAction("Index", "Deneme");
                    }
                    else
                    {
                        await _userManager.AccessFailedAsync(user);
                        

                        int fail = await _userManager.GetAccessFailedCountAsync(user);


                        ModelState.AddModelError("", $"{fail} kez başarısız giriş");
                        if (fail==3)
                        {
                            await _userManager.SetLockoutEndDateAsync(user, new DateTimeOffset(DateTime.Now.AddMinutes(20)));
                            ModelState.AddModelError("", "Hesabınız 3 başarısız giriş nedeni ile 20 dakika süre ile kilitlenmiştir. Lütfen daha sonra tekrar deneyniz.");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifresi"); 
                        }
                    }
                


                }
                else
                {
                    ModelState.AddModelError("", "Bu email adresine kayıtlı kullanıcı bulunamamıştır.");
                }
            }
            return View(loginViewModel);
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


        public IActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ResetPassword(PasswordResetViewModel passwordResetViewModel)
        {
            User user = _userManager.FindByEmailAsync(passwordResetViewModel.Email).Result;
            if (user != null)
            {
                string passwordResetToken = _userManager.GeneratePasswordResetTokenAsync(user).Result;
                string passwordResetLink = Url.Action("ResetPassowrdConfirm", "User", new { userId = user.Id, token = passwordResetToken }, HttpContext.Request.Scheme);

                Helper.PasswordReset.PasswordResetSendEmail(passwordResetLink, passwordResetViewModel.Email, user.UserName);

                ViewBag.status = "success";
            }
            else
            {
                ModelState.AddModelError("","Sistemde kayıtlı email adresine ulaşılamamıştır.");
            }
          
            return View(passwordResetViewModel);
        }

        public IActionResult ResetPasswordConfirm(string userId,string token)
        {
            TempData["UserId"] = userId;
            TempData["Token"] = token;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPasswordConfirm([Bind("PasswordNew")]PasswordResetViewModel passwordResetViewModel)
        {
            string token = TempData["Token"].ToString();
            string userId = TempData["UserId"].ToString();
            User user = await _userManager.FindByIdAsync(userId);

            if (user!=null)
            {
                IdentityResult result = await _userManager.ResetPasswordAsync(user, token, passwordResetViewModel.PasswordNew);
                if (result.Succeeded)
                {
                    await _userManager.UpdateSecurityStampAsync(user);
                    TempData["PasswordResetInfo"] = "Şifreniz başarıyla yenilenmiştir.Yeni şifreniz ile giriş yapabiliirsiniz.";
                    ViewBag.status = "succes";
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Bir hata meydana gelmiştir.");
            }


            return View();

        }


    }
}
