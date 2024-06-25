﻿using Newtonsoft.Json;

namespace Assignment.Service.Model.Request;

public class CollectionOfIsbn
{
    [JsonProperty("isbn")]
    public string Isbn { get; set; }
}

public class AddBookToCollectionDtoReq
{
    [JsonProperty("userId")]
    public string UserId { get; set; }

    [JsonProperty("collectionOfIsbns")]
    public List<CollectionOfIsbn> CollectionOfIsbns { get; set; }
}