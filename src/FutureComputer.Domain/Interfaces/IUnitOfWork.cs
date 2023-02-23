namespace FutureComputer.Domain.Interfaces;

public interface IUnitOfWork<T>
{
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}