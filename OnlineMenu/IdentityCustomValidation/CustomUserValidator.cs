using Microsoft.AspNetCore.Identity;
using OnlineMenu.Core.Entities;

namespace OnlineMenu.UI.IdentityCustomValidation
{
    public class CustomUserValidator : IUserValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            List<IdentityError> errors = new List<IdentityError>();
            string[] Digits = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            foreach (var item in Digits)
            {
                if (user.UserName[0].ToString()==item)
                {
                    errors.Add(new IdentityError() { Code = "UserNameContainsFirstLetterDigit", Description = "Kullanıcı adının ilk harfi sayısal karakter içeremez." });
                }
            }
            if (errors.Count==0)
            {
                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }
        }
    }
}
