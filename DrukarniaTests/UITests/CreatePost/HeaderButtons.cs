using DrukarniaTests.Constants;
using DrukarniaTests.Helpers;
using DrukarniaTests.POM.Methods;
using DrukarniaTests.POM.Methods.PostPageMeth;

namespace DrukarniaTests.UITests.CreatePost
{
    public class HeaderButtons
    {
        AuthorizationController controller = new AuthorizationController();
        HeaderButtonsMeth headerButtons = new HeaderButtonsMeth();

        [Test]
        public async Task CheckHomePageButtonsWorkCorrect()
        {
            headerButtons.ClickOnHomePageButton();
            BrowserHelper.IsUrlCorrect(UrlConsts.HomePage).Should().BeTrue();
        }

        [Test]
        public async Task CheckSearchButtonWorkCorrect()
        {
            headerButtons.ClickSearchButton();
            BrowserHelper.IsUrlCorrect(UrlConsts.SearchPage).Should().BeTrue();
        }

        [Test]
        public async Task CheckCreatePostButtonInactive()
        {
            headerButtons.ClickCreatePostButton();
            BrowserHelper.IsUrlCorrect(UrlConsts.CreatePostPage).Should().BeTrue();
        }

        [Test]
        public async Task CheckSavedButtonWorkCorrect()
        {
            headerButtons.ClickSavedLongreadsButton();
            BrowserHelper.IsUrlCorrect(UrlConsts.BookmarksPage).Should().BeTrue();
        }

        [Test]
        public async Task CheckNotificationButtonWorkCorrect()
        {
            headerButtons.ClickNotificationButton();
            BrowserHelper.IsUrlCorrect(UrlConsts.NotificationPage).Should().BeTrue();
        }

        [Test]
        public void CheckDraftsButtonWorkCorrect() { }

        [Test]
        public void ChecPublicatePostButtonkWorkCorrect() { }

        #region SetUp
        [SetUp]
        public async Task SetUp()
        {
            BrowserHelper.GetBrowser().Navigate().GoToUrl(UrlConsts.BaseURL);
            await controller.LoginWithApi(BaseConstants.EmailForLogin, BaseConstants.PasswordForLogin);
            BrowserHelper.GetBrowser().Navigate().GoToUrl(UrlConsts.CreatePostPage);
            BrowserHelper.Crutch();
        }
        #endregion

        #region TearDown
        /*[TearDown]
        public void CleanBrowser() =>
            BrowserHelper.CleanDriver();*/

        [TearDown]
        public void CloseBrowser() =>
            BrowserHelper.CloseDriver();
        #endregion
    }
}
