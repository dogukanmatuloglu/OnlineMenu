using Microsoft.AspNetCore.Mvc;
using OnlineMenu.UI.ViewModels;

namespace OnlineMenu.UI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(UserViewModel userViewModel)
        {
            return View();
        }


    }
}
