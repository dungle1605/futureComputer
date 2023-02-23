using FutureComputer.Domain.Interfaces;

namespace FutureComputer.Infrastructure.Domain;

public class UnitOfWork<T> : IUnitOfWork<T> where T : class, IAggregateRoot
{
    private readonly IRepository<T> _repository;

    public UnitOfWork(IRepository<T> repository)
    {
        _repository.
    }
    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}