using GerenciadorHospital.Models;
using Microsoft.AspNetCore.Identity;

namespace GerenciadorHospital.Utils
{
    public class BCryptPasswordHasher<TUser> : PasswordHasher<TUser> where TUser : class
    {
        public override string HashPassword(TUser user, string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public override PasswordVerificationResult VerifyHashedPassword(TUser user, string hashedPassword, string providedPassword)
        {
            if (BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword))
            {
                return PasswordVerificationResult.Success;
            }
            else
            {
                return PasswordVerificationResult.Failed;
            }
        }
    }
}
