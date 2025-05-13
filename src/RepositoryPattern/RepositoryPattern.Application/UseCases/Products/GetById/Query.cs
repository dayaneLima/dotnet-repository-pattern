using Mediator.Abstractions;
using RepositoryPattern.Domain.Abstractions;

namespace RepositoryPattern.Application.UseCases.Products.GetById;


public sealed record Query(Guid Id) : IRequest<Result<Response>>;