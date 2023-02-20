using Ardalis.Specification;

namespace FutureComputer.Domain.Interfaces;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot { }