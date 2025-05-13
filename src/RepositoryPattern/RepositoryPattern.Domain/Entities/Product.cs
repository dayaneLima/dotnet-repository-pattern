using RepositoryPattern.Domain.Abstractions;

namespace RepositoryPattern.Domain.Entities;

public class Product : Entity, IAggregateRoot
{
    public string Title { get; set; } = string.Empty;
}