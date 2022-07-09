using System.ComponentModel.DataAnnotations;

namespace OnlineMenu.UI.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="Email Adresiniz")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name ="Şifreniz")]
        [Required]
        [DataType(DataType.Password)]
        [MinLength(4,ErrorMessage ="Şifreniz en az 4 karakter olmalı")]
        public string Password { get; set; }
    }
}
