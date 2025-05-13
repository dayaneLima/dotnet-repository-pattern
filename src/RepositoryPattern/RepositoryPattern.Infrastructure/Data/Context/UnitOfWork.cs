using RepositoryPattern.Domain.Abstractions;

namespace RepositoryPattern.Infrastructure.Data.Context;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task<bool> CommitAsync()
        => await context.SaveChangesAsync() > 0;
}
