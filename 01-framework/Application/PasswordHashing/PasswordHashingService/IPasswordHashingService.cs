

namespace _01_framework.Application.PasswordHashing.PasswordHashingService
{

    public interface IPasswordHashingService
    {

        bool VerifyHashedPassword(string hashedPassword, string providedPassword);
        string HashPassword(string password);
    }
}
