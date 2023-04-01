using DrukarniaTests.Constants;
using DrukarniaTests.Controllers;
using DrukarniaTests.Helpers;
using DrukarniaTests.POM.Methods;
using OpenQA.Selenium;

namespace DrukarniaTests.UITests
{
    public class Authorization
    {
        AuthMethods authMethods = new AuthMethods();
        AuthorizationController authorizationController = new AuthorizationController();

        [Test]
        public void LoginWithValidData()
        {
            authMethods.OpenAuthModalWindow();
            authMethods.ClickContinueWithEmail();
            authMethods.EnterDataInEmailField(BaseConstants.EmailForLogin);
            authMethods.EnterDataInpasswordFiled(BaseConstants.PasswordForLogin);
            authMethods.ClickSubmitButton();

            BrowserHelper.GetCurrentUrlWithWait(BrowserHelper.GetBrowser().Url.ToString(), BaseConstants.HomePage).Should().BeTrue();
        }

        #region SetUp
        [SetUp]
        public void SetUpURL() =>
            BrowserHelper.GetBrowser().Navigate().GoToUrl(BaseConstants.BaseURL);
        #endregion

        #region TearDown
        [OneTimeTearDown]
        public void CloseBrowser() => BrowserHelper.CloseDriver();

        [TearDown]
        public void OpenNewWindow() => BrowserHelper.CleanDriver();
        #endregion
    }
}