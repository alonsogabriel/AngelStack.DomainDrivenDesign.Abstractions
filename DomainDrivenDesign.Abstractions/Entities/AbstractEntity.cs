using DomainDrivenDesign.Abstractions.Attributes;
using DomainDrivenDesign.Abstractions.Interfaces;

namespace DomainDrivenDesign.Abstractions.Entities;

public abstract class AbstractEntity<T>
{
    protected AbstractEntity() { }
    protected AbstractEntity(T id) => Id = id;

    [ClaimBinding("sub")]
    public T Id { get; protected set; }

    [ClaimBinding("created_at")]
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    [ClaimBinding("updated_at")]
    public DateTime? UpdatedAt { get; protected set; }
    public virtual void Touch()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}

public abstract class AbstractEntity : AbstractEntity<Guid>
{
    protected AbstractEntity() : base(Guid.NewGuid()) { }
}

public abstract class AbstractEntitySoftDelete<T> : AbstractEntity<T>, ISoftDelete
{
    protected AbstractEntitySoftDelete() : base() { }
    protected AbstractEntitySoftDelete(T id) : base(id) { }

    public DateTime? DeletedAt { get; protected set; }

    public bool IsDeleted => DeletedAt != null;

    public virtual void Delete()
    {
        DeletedAt = DateTime.UtcNow;
    }

    public virtual void Restore()
    {
        Touch();
        DeletedAt = null;
    }
}

public abstract class AbstractEntitySoftDelete : AbstractEntitySoftDelete<Guid>
{
    protected AbstractEntitySoftDelete() : base(Guid.NewGuid()) { }
}
