namespace AngelStack.DomainDrivenDesign.Abstractions;

public interface ISoftDelete
{
    DateTime? DeletedAt { get; }
    void Delete();
    void Restore();
}