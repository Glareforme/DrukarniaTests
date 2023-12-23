using GSF.Security.Cryptography;

namespace DrukarniaTests.Helpers
{
    internal class UserDataGenerator
    {


        internal static string GenerateMail()
        {
            var tempEmailAndPassword = new Dictionary<string, string>();
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
