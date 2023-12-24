using GSF.Security.Cryptography;

namespace DrukarniaTests.Helpers
{
    internal class UserDataGenerator
    {


        internal static string GenerateMail()
        {
            string tempMail = "test";
            tempMail += (DateTime.Now.ToBinary() * -1 + "@gmail.com");
            return tempMail;
        }

        internal static string GeneratePassword()
        {
            var generator = new PasswordGenerator();
            return generator.GeneratePassword();
        }
    }
}
