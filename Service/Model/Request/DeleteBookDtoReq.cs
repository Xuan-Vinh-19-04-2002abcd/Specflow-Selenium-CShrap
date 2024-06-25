using Newtonsoft.Json;

namespace Assignment.Service.Model.Request;

public class DeleteBookDtoReq
{  
    [JsonProperty("isbn")]
    public string Isbn { get; set; }
    [JsonProperty("userId")]
    public string UserId { get; set; }
}