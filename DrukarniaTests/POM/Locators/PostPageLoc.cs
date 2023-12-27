using OpenQA.Selenium;

namespace DrukarniaTests.POM.Locators
{
    internal class PostPageLoc
    {
        #region Upper buttons
        public static By HomePageButton = By.XPath("//span[text()='Друкарня']");
        public static By PersonFeedButton = By.XPath("//a[contains(@title,'стрічка')] or contains(text(),'стрічка')]");
        public static By SearchButton = By.XPath("//a [contains(@title,'ошук')] or contains(text(),'ошук')]");
        public static By CreatePostButton = By.XPath("//a [contains(@title,'аписати') or contains(text(),'аписати')]");
        public static By SavedLongreadsButton = By.XPath("//a [contains(@title,'бережені') or contains(text(),'бережені')]");
        public static By DraftsButton = By.XPath("//span [contains(text(),'ернетки')]");
        public static By ReleaseLongread = By.XPath("//button[@class='call-to-action']");
        #endregion

        #region Page field 
        public static By ArcticleTitleField = By.XPath("//h1[@class='article__title']");
        public static By ArcticleContentField = By.XPath("//h1[@class='article__title']/following-sibling::p");
        #endregion
    }
}
