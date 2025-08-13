namespace DomainDrivenDesign.Abstractions.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class ClaimBinding(string claimType) : Attribute
{
    public string ClaimType { get; } = claimType;
}
