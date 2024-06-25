namespace Assignment.Test.DataObject;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public string Display()
    {
        return $"Title: {Title}, Author: {Author}, Publisher: {Publisher}";
    }
}