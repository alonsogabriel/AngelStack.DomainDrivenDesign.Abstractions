using System.Reflection;
using DomainDrivenDesign.Abstractions.Attributes;
using DomainDrivenDesign.Abstractions.Validations;

namespace DomainDrivenDesign.Abstractions.ValueObjects;

public abstract record StringValue
{
    public StringValue(string value)
    {
        Value = value;
        Validate();
    }
    public string Value { get; protected set; }
    public int Length => Value.Length;

    protected abstract void Validate();
}