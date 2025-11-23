using System;
using Domain.Entities;

namespace Application.Abstractions.Repositories;

public interface IActorRepository : IGenericRepository<Actor>
{
    IEnumerable<Actor> GetActiveActors();
}
