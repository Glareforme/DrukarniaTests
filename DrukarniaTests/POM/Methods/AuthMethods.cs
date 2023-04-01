namespace DrukarniaTests.POM.Methods
{
    using DrukarniaTests.Constants;
    using DrukarniaTests.Helpers;
    using DrukarniaTests.POM.Locators;

    internal class AuthMethods
    {
        public void OpenAuthModalWindow() =>
            BrowserHelper.FindElementWithWaits(AuthLoc.AuthorizeButton, BaseConstants.LongWait).Click();
        public void ClickContinueWithEmail() =>
            BrowserHelper.FindElementWithWaits(AuthLoc.ContinueWithEmailButton, BaseConstants.LongWait).Click();
        public void EnterDataInEmailField(string email) =>
            BrowserHelper.FindElementWithWaits(AuthLoc.EmailInputField, BaseConstants.LongWait).SendKeys(email);
        public void EnterDataInpasswordFiled(string password) =>
            BrowserHelper.FindElementWithWaits(AuthLoc.PasswordInputField, BaseConstants.LongWait).SendKeys(password);
        public void ClickSubmitButton() =>
            BrowserHelper.FindElementWithWaits(AuthLoc.AuthSubmitButton, BaseConstants.LongWait).Click();
    }
}
