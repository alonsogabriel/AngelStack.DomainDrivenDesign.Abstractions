namespace DomainDrivenDesign.Abstractions.Interfaces;

public interface IUnitOfWork : ITransaction
{
    IRepository<T> GetRepository<T>() where T: class;
}