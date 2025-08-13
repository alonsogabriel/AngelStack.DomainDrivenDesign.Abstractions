using System.Text.Json;

namespace DomainDrivenDesign.Abstractions.Extensions;

public static class GenericExtensions
{
    public static KeyValuePair<TKey, TValue> WithKey<TKey, TValue>(this TValue value, TKey key)
    {
        return new KeyValuePair<TKey, TValue>(key, value);
    }
    public static KeyValuePair<string, TValue> WithKey<TValue>(this TValue value, string key)
    {
        return value.WithKey<string, TValue>(key);
    }

    public static string ToJson<T>(this T value, JsonSerializerOptions? options = null)
    {
        options ??= new JsonSerializerOptions
        {
            WriteIndented = false,
        };
        return JsonSerializer.Serialize(value, options);
    }

    public static T Guard<T>(this T? value, Exception exception)
    {
        return value ?? throw exception;
    }

    public static T Guard<T>(this T? value)
    {
        var exception = new ArgumentNullException(nameof(value));

        return value.Guard(exception);
    }
}
