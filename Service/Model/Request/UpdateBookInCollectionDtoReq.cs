using Newtonsoft.Json;

namespace Assignment.Service.Model.Request;

public class UpdateBookInCollectionDtoReq
{
    [JsonProperty("userId")]
    public string UserId { get; set; }
    [JsonProperty("isbn")]
    public string Isbn { get; set; }
  
}