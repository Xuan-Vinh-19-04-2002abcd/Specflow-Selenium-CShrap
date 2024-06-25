using Newtonsoft.Json;

namespace Assignment.Service.Model.Response;

public class GetAllBookResponse
{
    [JsonProperty("books")] 
    public List<BookingColectionDtoRes> Books { get; set; }
}