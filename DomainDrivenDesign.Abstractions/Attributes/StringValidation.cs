using System.Diagnostics.CodeAnalysis;

namespace DomainDrivenDesign.Abstractions.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class StringValidation : Attribute
{
    public bool Required { get; init; } = true;
    public int MinLength { get; init; } = 0;
    public int MaxLength { get; init; } = int.MaxValue;

    [StringSyntax(StringSyntaxAttribute.Regex)]
    public string? Pattern { get; init; } = null;
}