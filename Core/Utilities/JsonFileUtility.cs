using System.Text.Json;
using Assignment.Core.Extensions;

namespace Assignment.Core.Utilities;

public class JsonFileUtility
{
    public static string ReadJsonFile(string path)
    {
        var filePath = StringExtensions.GetAbsolutePath(path);  

        return File.ReadAllText(path);
    }
    public static Dictionary<string, T> ReadAndParse<T>(string filepath)
    {
        var jsonData = File.ReadAllText(filepath);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var data = JsonSerializer.Deserialize<Dictionary<string, T>>(jsonData, options);
        return data ?? new Dictionary<string, T>();
    }
}