﻿namespace AngelStack.DomainDrivenDesign.Abstractions;

public interface IUnitOfWork
{
    IRepository<T> GetRepository<T>() where T: class;
    Task SaveChangesAsync(CancellationToken cancellationToken);
}