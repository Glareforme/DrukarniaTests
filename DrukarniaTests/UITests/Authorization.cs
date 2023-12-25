using DrukarniaTests.Constants;
using DrukarniaTests.Helpers;
using DrukarniaTests.POM.Locators;
using DrukarniaTests.POM.Methods;

namespace DrukarniaTests.UITests
{
    public class Authorization
    {
        AuthMethods authMethods = new AuthMethods();

        [Test]
        public void LoginWithValidData()
        {
            authMethods.OpenProfileModalWindow();
            authMethods.ClickOnSignInButton();
            authMethods.ClickContinueWithEmail();
            authMethods.EnterDataInEmailField(BaseConstants.EmailForLogin);
            authMethods.EnterDataInpasswordFiled(BaseConstants.PasswordForLogin);
            authMethods.ClickSubmitButton();

            BrowserHelper.IsUrlCorrect(UrlConsts.HomePage).Should().BeTrue();
        }

        [Test]
        public void LoginWithUnregistratedUserData()
        {
            authMethods.OpenProfileModalWindow();
            authMethods.ClickOnSignInButton();
            authMethods.ClickContinueWithEmail();
            authMethods.EnterDataInEmailField(UserDataGenerator.GenerateMail());
            authMethods.EnterDataInpasswordFiled(UserDataGenerator.GeneratePassword());
            authMethods.ClickSubmitButton();

            BrowserHelper.IsUrlCorrect(UrlConsts.HomePage).Should().BeFalse();
        }

        [Test]
        public void TryLoginWithInvalidUserData()
        {
            authMethods.OpenProfileModalWindow();
            authMethods.ClickOnSignInButton();
            authMethods.ClickContinueWithEmail();
            authMethods.EnterDataInEmailField("test email");
            authMethods.EnterDataInpasswordFiled("test password");

            BrowserHelper.FindElementWithoutWait(AuthLoc.AuthSubmitButton).Enabled.Should().BeFalse();

            authMethods.EnterDataInEmailField(String.Empty);
            authMethods.EnterDataInpasswordFiled(String.Empty);

            BrowserHelper.FindElementWithoutWait(AuthLoc.AuthSubmitButton).Enabled.Should().BeFalse();

            authMethods.EnterDataInEmailField("1231231");
            authMethods.EnterDataInpasswordFiled("4562364573456");

            BrowserHelper.FindElementWithoutWait(AuthLoc.AuthSubmitButton).Enabled.Should().BeFalse();

            authMethods.EnterDataInEmailField("פ³גאהערןפלסקסקÿל");
            authMethods.EnterDataInpasswordFiled("ב‏üב‏...12");

            BrowserHelper.FindElementWithoutWait(AuthLoc.AuthSubmitButton).Enabled.Should().BeFalse();
        }

        #region SetUp

        [SetUp]
        public void SetUpURL()
        {
            BrowserHelper.GetBrowser().Navigate().GoToUrl(UrlConsts.BaseURL);
            BrowserHelper.Crutch();
        }

        #endregion

        #region TearDown

        [TearDown]
        public void CloseTab() => BrowserHelper.CleanDriver();

        [OneTimeTearDown]
        public void TearDown() => BrowserHelper.CloseDriver();

        #endregion
    }
}