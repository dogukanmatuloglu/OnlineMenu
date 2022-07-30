using System.ComponentModel.DataAnnotations;

namespace OnlineMenu.UI.ViewModels
{
    public class PasswordResetViewModel
    {
        [Display(Name ="Email Adresiniz")]
        [Required(ErrorMessage ="Email Adresiniz Gereklidir.")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name ="Yeni Şifreniz")]
        [Required(ErrorMessage ="Şifre Alanı Gereklidir.")]
        [DataType(DataType.Password)]
        [MinLength(4,ErrorMessage ="Şifreniz En Az 4 Karakterli Olmalıdır.")]
        public string PasswordNew { get; set; }
    }
}
