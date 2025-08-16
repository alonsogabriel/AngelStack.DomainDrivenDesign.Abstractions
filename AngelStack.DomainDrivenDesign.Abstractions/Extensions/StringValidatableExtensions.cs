using System.Reflection;
using AngelStack.Common.Guards;
using AngelStack.Common.Strings;

namespace AngelStack.DomainDrivenDesign.Abstractions.Extensions;

public static class StringValidatableExtensions
{
    public static bool IsRequired<T>() where T : StringValidatable
    {
        return typeof(T).Guard().GetCustomAttribute<Required>()?.Value ?? false;
    }

    public static int? GetMinLength<T>()
    {
        return typeof(T).Guard().GetCustomAttribute<MinLength>()?.Value;
    }

    public static int? GetMaxLength<T>()
    {
        return typeof(T).GetCustomAttribute<MaxLength>()?.Value;
    }

    public static string? GetRegularExpression<T>()
    {
        return typeof(T).Guard().GetCustomAttribute<RegularExpression>()?.Value;
    }
}
