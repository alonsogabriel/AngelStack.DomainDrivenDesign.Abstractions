using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;
using System.Text.Json;

namespace DomainDrivenDesign.Abstractions.Extensions;

public static partial class StringExtensions
{
    public static string RemoveDiacritics(this string text)
    {
        var normalized = text.Normalize(NormalizationForm.FormD);
        var builder = new StringBuilder();

        foreach (var ch in normalized)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(ch);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                builder.Append(ch);
            }
        }

        return builder.ToString().Normalize(NormalizationForm.FormC);
    }

    public static Guid ToGuid(this string value)
    {
        return Guid.Parse(value);
    }

    public static string RemoveExtraSpaces(this string value)
    {
        return ExtraSpaceRegex().Replace(value.Trim(), " ");
    }

    public static T ParseEnum<T>(this string value, bool ignoreCase = true) where T : struct, Enum
    {
        return Enum.Parse<T>(value, ignoreCase);
    }

    public static T? ParseJson<T>(this string json, JsonSerializerOptions? options = null)
    {
        options ??= new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
        return JsonSerializer.Deserialize<T>(json, options);
    }

    [GeneratedRegex(" {2,}", RegexOptions.Compiled)]
    private static partial Regex ExtraSpaceRegex();
}
