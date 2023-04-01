using OpenQA.Selenium;

namespace DrukarniaTests.POM.Locators
{
    internal class AuthLoc
    {
        public static By AuthorizeButton = By.CssSelector(".ml-auto .button");
        public static By ContinueWithEmailButton = By.CssSelector(".auth__header .auth__option");
        public static By EmailInputField = By.Id("email");
        public static By PasswordInputField = By.Id("password");
        public static By AuthSubmitButton = By.CssSelector(".auth-button");
        public static By CloseAuthModal = By.CssSelector(".cross-btn");
        public static By DisplayPasswordButton = By.CssSelector(".eye");
    }
}
