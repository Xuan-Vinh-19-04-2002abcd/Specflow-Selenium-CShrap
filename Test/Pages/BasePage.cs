using Assignment.Core.Driver;
using Assignment.Core.Element;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Assignment.Test.Pages;

public class BasePage
{
    public void CloseAlert()
    {
        DriverManager.Wait.Until(ExpectedConditions.AlertIsPresent());
        DriverManager.WebDriver.SwitchTo().Alert().Accept();
    }
}