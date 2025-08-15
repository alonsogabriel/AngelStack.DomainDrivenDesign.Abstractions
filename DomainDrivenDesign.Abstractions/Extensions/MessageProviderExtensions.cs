using AngelStack.Common.Guards;
using AngelStack.Common.Strings;
using DomainDrivenDesign.Abstractions.Interfaces;

namespace DomainDrivenDesign.Abstractions.Extensions;

public static class MessageProviderExtensions
{
    public static string GetMessage(this IMessageProvider provider, string name, StringReplacements replacements)
    {
        provider.Guard();
        replacements.Guard();

        if (string.IsNullOrEmpty(name)) return string.Empty;

        return provider.GetMessage(name).ReplaceAll(replacements);
    }

    public static string GetMessage(this IMessageProvider provider, string name, string replacements)
    {
        return provider.GetMessage(name, replacements.ToReplacements());
    }
}