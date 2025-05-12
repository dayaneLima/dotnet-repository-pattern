using RepositoryPattern.Domain.Abstractions;
using RepositoryPattern.Domain.Entities;
using System.Linq.Expressions;

namespace RepositoryPattern.Domain.Specifications.Products;

public class GetProductByIdSpecification(Guid id) : Specification<Product>
{
    public override Expression<Func<Product, bool>> ToExpression()
        => product => product.Id == id;
}