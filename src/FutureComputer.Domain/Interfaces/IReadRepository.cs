using Ardalis.Specification;

namespace FutureComputer.Domain.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{

}