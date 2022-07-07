using Microsoft.AspNetCore.Identity;
using OnlineMenu.Core.Entities;

namespace OnlineMenu.UI.IdentityCustomValidation
{
    public class CustomPasswordValidator : IPasswordValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
        {
           List<IdentityError> identityErrors = new List<IdentityError>();
            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                if (!user.Email.Contains(user.UserName))
                {
                    identityErrors.Add(new IdentityError() { Code = "PasswordContainsUserName", Description = "Şifre Alanı Kullanıcı Adı İçeremez." });
                }
               
            }

            if (password.ToLower().Contains("1234"))
            {
                identityErrors.Add(new IdentityError() { Code = "PasswordContains1234", Description = "Şifre alanı ardışık sayı içeremez" });
            }
           
            if (password.ToLower().Contains(user.Email.ToLower()))
            {
                identityErrors.Add(new IdentityError() { Code = "PasswordContainsEmail", Description = "Şifre alanı email adresi içeremez" });
            }


            if (identityErrors.Count == 0)
            {
                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed(identityErrors.ToArray()));
            }

        }
    }
}
