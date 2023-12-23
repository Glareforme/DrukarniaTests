using OpenQA.Selenium;

namespace DrukarniaTests.POM.Locators
{
    internal class AuthLoc
    {
        public static By AuthorizeButton = By.XPath("//header/div/span/button");
        public static By LoginButton = By.XPath("//div[@class='tippy-content']//div/a[contains(@href,'login')][1]");
        public static By ContinueWithEmailButton = By.XPath("//div[@id='sidebar']//button/img/..");
        public static By EmailInputField = By.Id("email");
        public static By PasswordInputField = By.Id("password");
        public static By AuthSubmitButton = By.XPath("//button[@type='submit']");
        public static By CloseAuthModal = By.CssSelector(".cross-btn");
        public static By DisplayPasswordButton = By.CssSelector(".eye");
    }
}
