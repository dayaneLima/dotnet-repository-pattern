using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Domain.Abstractions;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Repositories;
using RepositoryPattern.Infrastructure.Data.Context;

namespace RepositoryPattern.Infrastructure.Repositories;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task CreateAsync(Product product, CancellationToken cancellationToken = default)
        => await context.Products.AddAsync(product, cancellationToken);

    public async Task<Product?> GetByIdAsync(Specification<Product> specification, CancellationToken cancellationToken = default)
        => await context
            .Products
            .AsNoTracking()
            .Where(specification.ToExpression())
            .FirstOrDefaultAsync(cancellationToken);
}
