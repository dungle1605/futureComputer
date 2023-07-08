namespace FutureComputer.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    void SaveChange(CancellationToken cancellationToken = default);
}