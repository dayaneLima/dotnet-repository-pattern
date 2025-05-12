using RepositoryPattern.Domain.Abstractions;

namespace RepositoryPattern.Domain.Repositories;

public interface IRepository<T> where T : IAggregateRoot;