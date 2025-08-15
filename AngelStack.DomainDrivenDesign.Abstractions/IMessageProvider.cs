namespace AngelStack.DomainDrivenDesign.Abstractions;

public interface IMessageProvider
{
    public string Language { get; set; }
    public string GetMessage(string name);
}
