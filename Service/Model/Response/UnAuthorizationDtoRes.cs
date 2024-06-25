using Newtonsoft.Json;

namespace Assignment.Service.Model.Response;

public class UnAuthorizationDtoRes
{
    [JsonProperty("code")] 
    public int Code { get; set; }
    [JsonProperty("message")] 
    public string Message { get; set; }
}