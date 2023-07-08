namespace FutureComputer.Domain.Interfaces;

public interface ICurrentUserService
{
    Guid? Id { get; }
    string Email { get; }
}