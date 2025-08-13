namespace DomainDrivenDesign.Abstractions.Interfaces;

public interface ISoftDelete
{
    DateTime? DeletedAt { get; }
    void Delete();
    void Restore();
}