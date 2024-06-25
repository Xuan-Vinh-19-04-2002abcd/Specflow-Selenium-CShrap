using System.Net;
using Assignment.Core.Utilities;
using FluentAssertions;
using Newtonsoft.Json;
using NJsonSchema;
using RestSharp;

namespace Assignment.Core.Extensions;

public static class RestExtensions
{
    public static async Task VerrifySchema(string responseContent, string pathFile)
    {
        var schema = await JsonSchema.FromJsonAsync(JsonFileUtility.ReadJsonFile(pathFile));
        schema.Validate(responseContent).Should().BeEmpty();
    }

    public static dynamic ConverttoDynamicObject(this RestResponse response)
    {
        return (dynamic)JsonConvert.DeserializeObject(response.Content);
    }

    public static void VerifyStatusCodeOk(this RestResponse response)
    {
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    public static void VerifyStatusCodeCreated(this RestResponse response)
    {
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }

    public static void VerifyStatusCodeBadRequest(this RestResponse response)
    {
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    public static void VerifyStatusCodeUnauthorized(this RestResponse response)
    {
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
    public static void VerifyStatusCodeForbidden(this RestResponse response)
    {
        response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
    }
    public static void VerifyStatusCodeInternalServerError(this RestResponse response)
    {
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
    }
}