﻿namespace Assignment.Test.Constant;

public class EndPointConstant
{
    public static string ResisterStudent = "automation-practice-form";
    public static string SearchBook = "books";
    public static string Login = "login";
    
    
    public const string GetUseEndpoint = "/Account/v1/User/{0}";
    public const string AddBookToCollectionEndPoint = "/BookStore/v1/Books";
    public const string DeleteBookFromCollectionEndPoint = "/BookStore/v1/Book";
    public const string ReplaceBookInCollectionEnpoint = "/BookStore/v1/Books/{0}";
    public const string GetAllBooks = "/BookStore/v1/Books";
    public const string GetDetailBook = "/BookStore/v1/Book";
    
}