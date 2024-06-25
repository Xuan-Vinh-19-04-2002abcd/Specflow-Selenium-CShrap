using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assignment.Core.API;
using Assignment.Core.Configuration;
using Assignment.Core.Extensions;
using Assignment.Core.Utilities;
using Assignment.Service;
using Assignment.Service.Helper;
using Assignment.Test.Constant;
using Assignment.Test.DataObject;
using Assignment.Test.DataProvider;
using TechTalk.SpecFlow;

namespace Assignment.Test.StepDefinitions;

[Binding]
public sealed class AddBookToCollectTionByAPI : BaseSteps
{
    private ScenarioContext _scenarioContext;
    private BookService _bookService;
    private UserService _userService;
    public AddBookToCollectTionByAPI(ScenarioContext scenarioContext) : base()
    {
        _scenarioContext = scenarioContext;
        _bookService = new BookService(ApiClient);
        _userService = new UserService(ApiClient);
    }
    
    [Given(@"I add book have isbn is ""(.*)"" and account key ""(.*)""")]
    public async Task GivenIAddBookHaveIsbnIsAndAccountKey(string isbn, string accountKey)
    {
        
    }


    [Given(@"I add book have account key ""(.*)""")]
    public async Task GivenIAddBookHaveAccountKey(string accountKey)
    {
        Account account = AccountData[accountKey];
        await _userService.StoreTokenAsync(accountKey, account);
        var token = _userService.GetToken(accountKey);
        
        var responseGetAllBooks = await _bookService.GetAllBookSuccess();
        var listBook = responseGetAllBooks.Data.Books;
        
        string isbn = DataProviders.IsbnProviderValid(listBook);
        
        BookDataHelper.StoreDataToDeleteBook(account.UserId,isbn,token);
        BookDataHelper.DeleteCreateBookFromStorage(_bookService);
        
        await _bookService.AddBookToCollectionSuccess(account.UserId,isbn, token);
        var responseGetDetailBook = await _bookService.GetDetailBookSuccess(isbn);
        
        _scenarioContext["titleBook"] = responseGetDetailBook.Data.Title;
        
    }
}