using Mediator.Abstractions;
using RepositoryPattern.Domain.Abstractions;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Repositories;

namespace RepositoryPattern.Application.UseCases.Products.Create;

public class Handler(IProductRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<Command, Result<Response>>
{
    public async Task<Result<Response>> HandleAsync(Command request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
        };

        await repository.CreateAsync(product, cancellationToken);
        await unitOfWork.CommitAsync();

        return Result.Success(new Response("Produto criado com sucesso"));
    }
}