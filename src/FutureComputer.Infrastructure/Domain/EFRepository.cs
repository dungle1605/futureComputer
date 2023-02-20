using FutureComputer.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FutureComputer.Infrastructure.Domain;

public class EFRepository<T> : EFRepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public EFRepository(FutureComputerDbContext context) : base(context)
    {

    }
}