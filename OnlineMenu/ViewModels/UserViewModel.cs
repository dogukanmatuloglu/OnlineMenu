using System.ComponentModel.DataAnnotations;

namespace OnlineMenu.UI.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Gereklidir.")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email Adresi Gereklidir.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre Gereklidir.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
