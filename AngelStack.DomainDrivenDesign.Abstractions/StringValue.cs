namespace AngelStack.DomainDrivenDesign.Abstractions;

public abstract record StringValue
{
    protected StringValue() { }
    public StringValue(string value)
    {
        Value = value;
        Validate();
    }
    public string Value { get; protected set; }
    public int Length => Value.Length;

    protected abstract void Validate();
}