using System.Configuration;
using Assignment.Core.API;
using Assignment.Core.Driver;
using Assignment.Core.Extensions;
using Assignment.Core.ShareData;
using Assignment.Core.Utilities;
using Assignment.Test.Constant;
using Assignment.Test.DataObject;
using TechTalk.SpecFlow;
using ConfigurationManager = Assignment.Core.Configuration.ConfigurationManager;

namespace Assignment.Test.Hook;
[Binding]
public class Hooks
{
    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        ConfigurationManager.ReadConfiguration(FileConstant.SettingFilePath.GetAbsolutePath());
    }

    [AfterTestRun]
    public static void AfterTestRun()
    {
        
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        DriverManager.InitializeBrowser(ConfigurationManager.GetConfiguration()["browser"]);
        DriverManager.WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        DriverManager.WebDriver.Manage().Window.Maximize();
        DataStorage.InitData();
    }
    [AfterScenario]
    public void AfterScenario()
    {
        DataStorage.ClearData();
        DriverManager.CloseDriver();
    }

    
}