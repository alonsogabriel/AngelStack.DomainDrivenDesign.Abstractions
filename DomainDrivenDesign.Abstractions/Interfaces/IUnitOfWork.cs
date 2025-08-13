namespace DomainDrivenDesign.Abstractions.Interfaces;

public interface IUnitOfWork : ITransaction
{
    IRepository<T> GetRepository<T>() where T: class;
}

public interface ICommonUnitOfWork : ITransaction
{
    ICommonRepository Repository { get; }
}