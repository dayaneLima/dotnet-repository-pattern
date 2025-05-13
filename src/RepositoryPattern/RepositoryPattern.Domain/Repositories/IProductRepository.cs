using RepositoryPattern.Domain.Abstractions;
using RepositoryPattern.Domain.Entities;

namespace RepositoryPattern.Domain.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<Product?> GetByIdAsync(Specification<Product> specification, CancellationToken cancellationToken = default);
    Task CreateAsync(Product product, CancellationToken cancellationToken = default);
}