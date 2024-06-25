using Assignment.Core.Element;
using Assignment.Core.Extensions;
using Assignment.Test.DataObject;
using OpenQA.Selenium;

namespace Assignment.Test.Pages;

public class BookstorePage
{
    
        protected Element inputSearch = new Element(By.Id("searchBox"));
        private Element _columnElement = new Element(By.XPath("//div[contains(@class, 'header-content')]"));
        private Element _listBooks = new Element(By.XPath("//div[@class='rt-tr-group']//div[@role='row']"));

        public void SearchBook(string textSearch)
        {
            inputSearch.EnterText(textSearch);
        }

        public List<Book> GetBooksListFromBookPage()
        {
            var booksElements = _listBooks.ConvertByToListIWebElements();
            var columnNames = GetColumnNames();

            return booksElements.Select(bookElement => GetBookInfo(bookElement, columnNames)).Where(book => book != null).ToList();
        }

        private List<string> GetColumnNames()
        {
            return _columnElement.ConvertByToListIWebElements().Select(column => column.Text).ToList();
        }

        private Book GetBookInfo(IWebElement bookElement, List<string> columnNames)
        {
            int titleIndex = columnNames.IndexOf("Title");
            int authorIndex = columnNames.IndexOf("Author");
            int publisherIndex = columnNames.IndexOf("Publisher");

            var cells = bookElement.FindElements(By.CssSelector("div[role='gridcell']"));

            if (titleIndex < 0 || authorIndex < 0 || publisherIndex < 0 || cells.Count <= Math.Max(titleIndex, Math.Max(authorIndex, publisherIndex)))
            {
                return null;
            }

            string title = cells[titleIndex].Text;
            string author = cells[authorIndex].Text;
            string publisher = cells[publisherIndex].Text;

            if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(author) && !string.IsNullOrWhiteSpace(publisher))
            {
                return new Book
                {
                    Title = title,
                    Author = author,
                    Publisher = publisher
                };
            }

            return null;
        }

        public bool IsBookContainTextSearch(List<Book> listBook, string textSearch)
        {
            return listBook.Any(book =>
                StringExtensions.IsSubstringIgnoreCase(book.Title, textSearch) ||
                StringExtensions.IsSubstringIgnoreCase(book.Author, textSearch) ||
                StringExtensions.IsSubstringIgnoreCase(book.Publisher, textSearch));
        }
}