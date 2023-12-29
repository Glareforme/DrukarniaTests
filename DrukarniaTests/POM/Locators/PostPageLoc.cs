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

        #region Text modification
        public static By HighlightBoldButton = By.XPath("//div//button[contains(@title, 'жирним')]");
        public static By ItalicsButton = By.XPath("//div//button[contains(@title, 'Курсив')]");
        public static By BigTitle = By.XPath("//div//button[contains(@title, 'Заголовок великий')]");
        public static By SmallTitle = By.XPath("//div//button[contains(@title, 'Заголовок малий')]");
        public static By LinkButton = By.XPath("//div//button[contains(@title, 'Посилання')]");
        public static By BigQuoteButton = By.XPath("//div//button[contains(@title, 'Велика цитата')]");
        public static By SmallQuoteButton = By.XPath("//div//button[contains(@title, 'Мала цитата')]");
        public static By AddCapitalLetter = By.XPath("//div//button[contains(@title, 'Додати буквицю')]");
        #endregion

        #region Add element 
        public static By AddElementButton = By.XPath("//div[@class='tippy-content']");
        public static By AddPhotoToPageButton = By.XPath("//button[@title='Фото']");
        public static By AddPhotoFromUnsplashButton = By.XPath("//button[contains(@title, 'Unsplash')] ");
        public static By AddVideoButton = By.XPath("//button[contains(@title, 'Відео')] ");
        public static By AddLinksButton = By.XPath("//button[contains(@title, 'Посилання на інші ресурси')]");
        public static By SeparateButton = By.XPath("///button[@title='Розділити']");
        public static By AddTableButton = By.XPath("//button[@title='Таблиця']");
        public static By AddCodeButton = By.XPath("//button[@title='Код']");
        #endregion

        #region Table settings
        public static By OpenTableSettingButton = By.XPath("//div[@id='plus-button']/button");
        public static By AddRowToTableButton = By.XPath("//div[@id='table-toolbox']/button[@title='Додати рядок']");
        public static By AddColumnToTableButton = By.XPath("//div[@id='table-toolbox']/button[@title='Додати стовпчик']");
        public static By DeleteTableButton = By.XPath("//div[@id='table-toolbox']/button[@title='Видалити таблицю']");
        #endregion

        #region FAQ Button
        public static By OpenFaqPopUp = By.Id("headlessui-menu-button-1");
        public static By ListOfFrequentQuestions = By.Id("headlessui-menu-items-2");
        #endregion

    }
}
