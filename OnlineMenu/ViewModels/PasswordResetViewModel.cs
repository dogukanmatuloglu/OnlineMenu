using System.ComponentModel.DataAnnotations;

namespace OnlineMenu.UI.ViewModels
{
    public class PasswordResetViewModel
    {
        [Display(Name ="Email Adresiniz")]
        [Required(ErrorMessage ="Email Adresiniz Gereklidir.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
