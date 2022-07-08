using Microsoft.AspNetCore.Identity;

namespace OnlineMenu.UI.IdentityCustomValidation
{
    public class CustomIdentityErrorDescriber:IdentityErrorDescriber
    {

        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError() { Code = "InvalidUserName", Description = $"Bu {userName} geçersizdir." };
        }
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError() { Code = "DuplicateUserName", Description = $"{userName} zaten kullanılmaktadır." };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError() { Code = "DublicateEmail", Description = $"Bu {email} kullanılmaktadır." };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError() { Code = "PasswordTooShort", Description = $"Şifreniz en az {length} karakter olmalıdır." };
        }

    }
    

}
