using Assignment.Test.Pages;
using FluentAssertions;
using OpenQA.Selenium.DevTools.V85.Profiler;
using TechTalk.SpecFlow;

namespace Assignment.Test.StepDefinitions;
[Binding]
public class DeleteBookSteps
{
    private ProfilePage _profilePage;
    private readonly ScenarioContext _scenarioContext;

    public DeleteBookSteps(ScenarioContext scenarioContext)
    {
        _profilePage = new ProfilePage();
        _scenarioContext = scenarioContext;
    }
    [Then(@"I confirm delete successfully")]
    public void ThenIConfirmDeleteSuccessfully()
    {
        var titleBook = _scenarioContext["titleBook"] as string;
        _profilePage.IsDeleteBookSuccessfully(titleBook).Should().BeTrue();
    }

    [When(@"I delete this book with this title")]
    public void WhenIDeleteThisBookWithThisTitle()
    {
        var titleBook = _scenarioContext["titleBook"] as string;
        _profilePage.DeleteBook(titleBook);
    }
}