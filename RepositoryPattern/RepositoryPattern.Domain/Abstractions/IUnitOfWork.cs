namespace RepositoryPattern.Domain.Abstractions;

public interface IUnitOfWork
{
    Task CommitAsync();
}