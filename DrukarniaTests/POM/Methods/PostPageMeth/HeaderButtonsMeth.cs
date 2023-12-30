using DrukarniaTests.Constants;
using DrukarniaTests.Helpers;
using DrukarniaTests.POM.Locators;




namespace DrukarniaTests.POM.Methods.PostPageMeth
{
    internal class HeaderButtonsMeth
    {
        public void ClickOnHomePageButton() =>
            BrowserHelper.FindElementWithWaits(PostPageLoc.HomePageButton, BaseConstants.ShortWait).Click();

        public void ClickPersonFeedButton() =>
            BrowserHelper.FindElementWithWaits(PostPageLoc.PersonFeedButton, BaseConstants.ShortWait).Click();

        public void ClickSearchButton() =>
            BrowserHelper.FindElementWithWaits(PostPageLoc.PersonFeedButton, BaseConstants.ShortWait).Click();

        public void ClickCreatePostButton() =>
            BrowserHelper.FindElementWithWaits(PostPageLoc.CreatePostButton, BaseConstants.ShortWait).Click();

        public void ClickSavedLongreadsButton() =>
            BrowserHelper.FindElementWithWaits(PostPageLoc.SavedLongreadsButton, BaseConstants.ShortWait).Click();

        public void ClickNotificationButton() =>
            BrowserHelper.FindElementWithWaits(PostPageLoc.NotificationButton, BaseConstants.ShortWait).Click();

        public void ClickDraftsButton() =>
            BrowserHelper.FindElementWithWaits(PostPageLoc.DraftsButton, BaseConstants.ShortWait).Click();

        public void ClickReleaseLongreadButton() =>
            BrowserHelper.FindElementWithWaits(PostPageLoc.ReleaseLongreadButton, BaseConstants.ShortWait).Click();
    }
}
