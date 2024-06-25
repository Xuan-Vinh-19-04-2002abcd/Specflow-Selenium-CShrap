using System.Globalization;
using System.Reflection;

namespace Assignment.Core.Extensions;

public static class StringExtensions
{
    public static string GetAbsolutePath(this string filePath)
    {
        string currentDirectoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        filePath = Path.Combine(currentDirectoryPath, filePath);
        if (File.Exists(filePath))
        {
            return filePath;
        }

        return string.Empty;
    }
    
    public static string ConvertDateFormat(string date)
    {
        date = date.Trim();
        string originalFormat = "dd MMMM yyyy";
        DateTime dateTime;
            
        if (DateTime.TryParseExact(date, originalFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
        {
            return dateTime.ToString("dd MMMM,yyyy");
        }
        else
        {
            return "Invalid Date Format";
        }
    }
    public static bool IsSubstringIgnoreCase(string source, string value)
    {
        return source.ToLower().Contains(value.ToLower());
    }

    
}