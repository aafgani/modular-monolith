using Application.Abstractions.Repositories;
using Domain.Entities;

public interface IUnitOfWork : IDisposable
{
    IActorRepository Actors { get; }
    Task<int> SaveAsync();
}
