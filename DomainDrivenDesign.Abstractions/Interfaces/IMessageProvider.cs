namespace DomainDrivenDesign.Abstractions.Interfaces;

public interface IMessageProvider
{
    public string Language { get; set; }
    public string GetMessage(string name);
}
