using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Assignment.Core.Driver;

public class DriverManager
{
    public static IWebDriver WebDriver ;
    public static WebDriverWait Wait;
    public static void InitializeBrowser(string browser)
    {
     
        if (browser == "chrome"){
            WebDriver = new ChromeDriver(ChromeDriverService.CreateDefaultService());
        }
        else if (browser == "firefox")
        {
            WebDriver = new FirefoxDriver();
        }
       Wait = new WebDriverWait(DriverManager.WebDriver, TimeSpan.FromSeconds(10));
        
    }

    public static void CloseDriver()
    {
        WebDriver.Quit();
    }
}