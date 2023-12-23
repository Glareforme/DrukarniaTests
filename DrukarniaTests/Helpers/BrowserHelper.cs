using DrukarniaTests.Constants;
using FluentAssertions.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
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
            options.AddArgument("--start-maximized");
            // options.AddArgument("--headless");
            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return _driver;
        }

        public static IWebDriver GetBrowser()
        {
            return _driver == null ? CreateBrowser() : _driver;
        }

        public static void Crutch() => Thread.Sleep(BaseConstants.LongWait.Seconds());

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
            IWebElement element = null;

            try
            {
                element = new WebDriverWait(_driver, TimeSpan.FromSeconds(waitTime)).Until(ExpectedConditions.ElementToBeClickable(selector));
                return element;
            }
            catch (WebDriverTimeoutException exception)
            {
                element = FindElementWithoutWait(selector);

                return element != null ? element :
                throw new WebDriverTimeoutException($@"Element not found before timeout: {exception}");
            }
        }

        public static IWebElement FindElementWithoutWait(By selector)
        {
            var element = _driver.FindElement(selector);
            return element.Displayed ? element : null;
        }

        public static WebDriverWait GetCurrentSessionInfo()
        {
            var sessionData = new WebDriverWait(GetBrowser(), TimeSpan.FromSeconds(BaseConstants.LongWait));
            return sessionData;
        }


        public static bool IsUrlCorrect(string expectedUrl)
        {
            try
            {
                return GetCurrentSessionInfo().Until(ExpectedConditions.UrlToBe(expectedUrl));
            }
            catch (WebDriverTimeoutException)
            {

                return false;
            }
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
