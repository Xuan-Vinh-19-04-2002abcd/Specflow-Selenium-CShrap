using Assignment.Core.ShareData;
using Assignment.Service.Model.Request;

namespace Assignment.Service.Helper;

public class BookDataHelper
{
    public static void StoreDataToDeleteBook(DeleteBookDtoReq deleteBookDtoReq,string token)
    {
        DataStorage.SetData("hasCreatedBook",true);
        DataStorage.SetData("DeleteBookReq",deleteBookDtoReq);
        DataStorage.SetData("token",token);
    }
    public static void StoreDataToDeleteBook(string userId,string isbn,string token)
    {
        var deleteBookDtoReqReq = new DeleteBookDtoReq()
        {
            Isbn = isbn,
            UserId = userId
        };
        DataStorage.SetData("hasCreatedBook",true);
        DataStorage.SetData("DeleteBookReq",deleteBookDtoReqReq);
        DataStorage.SetData("token",token);
    }

    public static void DeleteCreateBookFromStorage(BookService bookService)
    {
        if ((bool)DataStorage.GetData("hasCreatedBook"))
        {
            bookService.DeleteBookSuccess(
                (DeleteBookDtoReq)DataStorage.GetData("DeleteBookReq"),
                (string)DataStorage.GetData("token"));
        }
    }
}