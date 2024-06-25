using Newtonsoft.Json;

namespace Assignment.Service.Model.Response;

public class AddBookToCollectionDt0Res
{
    [JsonProperty("books")] 
    public List<BookId> Books { get; set; }
}

public class BookId
{
    [JsonProperty("isbn")]
    public string Isbn { get; set; }
}