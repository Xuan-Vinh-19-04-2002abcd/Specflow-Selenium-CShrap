using Assignment.Core.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Assignment.Core.Extensions
{
    public static class ElementExtensions
    {
        public static IWebElement WaitForElementToBeVisible(this Element.Element element)
        {
            return DriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(element.By));
        }

        public static bool IsElementDisplayed(this Element.Element element)
        {
            try
            {
                return DriverManager.Wait.Until(ExpectedConditions.ElementIsVisible(element.By)).Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static IWebElement WaitForElementToBeClickEnable(this Element.Element element)
        {
            return DriverManager.Wait.Until(ExpectedConditions.ElementToBeClickable(element.By));
        }

        public static void WaitForElementGotoUrl(string url)
        {
            DriverManager.Wait.Until(ExpectedConditions.UrlToBe(url));
        }

        public static void EnterText(this Element.Element element, string text)
        {
            IWebElement webElement = element.WaitForElementToBeVisible();
            webElement.Clear();
            webElement.SendKeys(text);
        }

        public static void ClickOnElement(this Element.Element element)
        {
            element.ScrollToElement();
            element.WaitForElementToBeClickEnable().Click();
        }

        public static void SubmitOnElement(this Element.Element element)
        {
            element.ScrollToElement();
            element.WaitForElementToBeClickEnable().Submit();
        }

        public static void SelectDropdownByText(this Element.Element element, string value)
        {
            IWebElement webElement = element.WaitForElementToBeVisible();
            SelectElement selectElement = new SelectElement(webElement);
            selectElement.SelectByText(value);
        }

        public static string GetTextElement(this Element.Element element)
        {
            return element.WaitForElementToBeVisible().Text;
        }

        public static void SelectDateFromDatePicker(this Element.Element element, string date)
        {
            IWebElement webElement = element.WaitForElementToBeVisible();
            webElement.SendKeys(Keys.Control + "a");
            webElement.SendKeys(date);
        }

        public static string GetCurrentUrl()
        {
            string initialUrl = DriverManager.WebDriver.Url;
            DriverManager.Wait.Until(driver =>
            {
                string currentUrl = driver.Url;
                return !string.IsNullOrEmpty(currentUrl) && currentUrl != initialUrl;
            });
            return DriverManager.WebDriver.Url;
        }

        public static List<IWebElement> ConvertByToListIWebElements(this Element.Element element)
        {
            var webElements = DriverManager.WebDriver.FindElements(element.By);
            return new List<IWebElement>(webElements);
        }

        public static void ScrollToElement(this Element.Element element)
        {
            IWebElement webElement = DriverManager.WebDriver.FindElement(element.By);
            IJavaScriptExecutor js = (IJavaScriptExecutor)DriverManager.WebDriver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
        }
    }
}
