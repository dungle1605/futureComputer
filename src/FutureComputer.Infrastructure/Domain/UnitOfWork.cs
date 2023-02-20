using FutureComputer.Domain.Interfaces;

namespace FutureComputer.Infrastructure.Domain;

public class UnitOfWork : IUnitOfWork
{
    public Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}