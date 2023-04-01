using DrukarniaTests.Constants;
using DrukarniaTests.Controllers;
using DrukarniaTests.Helpers;
using DrukarniaTests.POM.Methods;

namespace DrukarniaTests.UITests
{
    public class Authorization
    {
        AuthMethods authMethods = new AuthMethods();

        [TestCase("***@gmail.com", "***")]
        public async Task LoginWithValidData(string email, string password)
        {
            authMethods.OpenAuthModalWindow();
            authMethods.ClickContinueWithEmail();
            authMethods.EnterDataInEmailField(email);
            authMethods.EnterDataInpasswordFiled(password);
            authMethods.ClickSubmitButton();

            BrowserHelper.GetBrowser().Url.Should().BeEquivalentTo("https://beta.drukarnia.com.ua/home");
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