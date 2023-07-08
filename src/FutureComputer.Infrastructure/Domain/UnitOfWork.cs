using FutureComputer.Domain.Interfaces;

namespace FutureComputer.Infrastructure.Domain;

public class UnitOfWork : IUnitOfWork
{
    private readonly FutureComputerDbContext _dbContext;

    public UnitOfWork(FutureComputerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void SaveChange(CancellationToken cancellationToken = default)
    {
        _dbContext.SaveChanges();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}