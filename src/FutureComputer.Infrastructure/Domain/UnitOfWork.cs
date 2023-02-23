using FutureComputer.Domain.Interfaces;

namespace FutureComputer.Infrastructure.Domain;

public class UnitOfWork : IUnitOfWork
{
    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}