using Assignment.Core.API;
using Assignment.Core.Configuration;
using Assignment.Core.Extensions;
using Assignment.Core.Utilities;
using Assignment.Test.Constant;
using Assignment.Test.DataObject;
using TechTalk.SpecFlow;

namespace Assignment.Test.StepDefinitions;

[Binding]
public class BaseSteps
{
    protected Dictionary<string, Account> AccountData;
    protected  APIClient ApiClient;

    public BaseSteps()
    {
        AccountData = JsonFileUtility.ReadAndParse<Account>(FileConstant.AccountDataFilePath.GetAbsolutePath());
        ApiClient = new APIClient(ConfigurationManager.GetConfiguration()["baseUrl"]);
    }
}