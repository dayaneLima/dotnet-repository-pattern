using Mediator.Abstractions;
using RepositoryPattern.Domain.Abstractions;

namespace RepositoryPattern.Application.UseCases.Products.Create;

public sealed record Command(string Title) : IRequest<Result<Response>>;