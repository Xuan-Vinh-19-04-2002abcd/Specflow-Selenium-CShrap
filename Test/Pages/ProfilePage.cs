using Assignment.Core.Driver;
using Assignment.Core.Element;
using Assignment.Core.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Assignment.Test.Pages;

public class ProfilePage : BasePage
{
    private Element _btnConfirmDelete = new Element(By.Id("closeSmallModal-ok"));
    private Element _btnDeleteBook(string bookTitle)
    {
        return new Element(By.XPath($"//a[text()='{bookTitle}']/ancestor::div[@role='row']//span[contains(@id,'delete')]"));
    }
 
    private Element GetTitleElement(string  title)
    {
        return new Element(By.XPath($"//a[text()='{title}']"));
    }
   
    public void DeleteBook(string title)
    {
        if (ElementExtensions.WaitForElementToBeClickEnable(GetTitleElement(title)).Displayed)
        {
            _btnDeleteBook(title).ClickOnElement();
            _btnConfirmDelete.ClickOnElement();
            CloseAlert();
        }
    }

    public bool IsDeleteBookSuccessfully(string title)
    {
        return !GetTitleElement(title).IsElementDisplayed();

    }
}