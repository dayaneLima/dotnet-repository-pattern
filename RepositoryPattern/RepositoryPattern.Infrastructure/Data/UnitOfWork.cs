using RepositoryPattern.Domain.Abstractions;

namespace RepositoryPattern.Infrastructure.Data;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CommitAsync()
        => await context.SaveChangesAsync();
}
