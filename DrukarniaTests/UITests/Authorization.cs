using DrukarniaTests.Constants;
using DrukarniaTests.Controllers;
using DrukarniaTests.Helpers;
using DrukarniaTests.POM.Methods;

namespace DrukarniaTests.UITests
{
    public class Authorization
    {
        AuthMethods authMethods = new AuthMethods();

        /// <summary>
        /// UI authorization is not working. After login with the correct credentials opens the registration module
        /// </summary>
        [TestCase("ronpo***@gamil.com", "***")]
        public async Task LoginWithValidData(string email, string password)
        {
            authMethods.OpenAuthModalWindow();
            authMethods.ClickContinueWithEmail();
            authMethods.EnterDataInEmailField(email);
            authMethods.EnterDataInpasswordFiled(password);
            authMethods.ClickSubmitButton();

            BrowserHelper.GetBrowser().Url.Should().BeEquivalentTo(BaseConstants.BaseURL);
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