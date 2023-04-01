using DrukarniaTests.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;

namespace DrukarniaTests.Helpers
{
    internal class BrowserHelper
    {
        private static IWebDriver _driver;
        private static ChromeOptions? options;
        private static Actions? action;

        public static IWebDriver CreateBrowser()
        {
            options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return _driver;
        }

        public static IWebDriver GetBrowser()
        {
            return _driver == null ? CreateBrowser() : _driver;
        }

        internal static void CleanDriver()
        {
            // Open new empty tab.
            _driver.ExecuteJavaScript("window.open('');");

            // Close all tabs but one tab and delete all cookies.
            for (var tabs = _driver.WindowHandles; tabs.Count > 1; tabs = _driver.WindowHandles)
            {
                _driver.SwitchTo().Window(tabs[0]);
                _driver.Manage().Cookies.DeleteAllCookies();
                _driver.Close();
            }

            // Switch to empty tab.
            _driver.SwitchTo().Window(_driver.WindowHandles[0]);
        }

        public static IWebElement FindElementWithWaits(By selector, int waitTime)
        {
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitTime));
                var element = wait.Until(wd => wd.FindElement(selector));

                return element;
            }
            catch (WebDriverTimeoutException exception)
            {
                throw new WebDriverTimeoutException($@"Element not found before timeout: {exception}");
            }
        }

        public static bool GetCurrentUrlWithWait(string expectedUrl, string actualUrl)
        {
            bool urlIsCorrect;
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(BaseConstants.LongWait));
            try
            {
                urlIsCorrect = wait.Until(x => x.Url.Equals(expectedUrl));
            }
            catch (WebDriverTimeoutException exception)
            {
                throw new WebDriverTimeoutException($@"Element not found before timeout: {exception}");
            }
            return urlIsCorrect;
        }

        internal static void MoveToElement(By selector)
        {
            action = new Actions(_driver);
            var element = _driver.FindElement(selector);
            action.MoveToElement(element);
            action.Perform();
        }

        internal static void CloseDriver() => _driver.Quit();
    }
}
