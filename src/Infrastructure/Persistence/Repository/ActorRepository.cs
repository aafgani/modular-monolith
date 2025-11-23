using System;
using Application.Abstractions.Repositories;
using Dapper;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence.Repository;

public class ActorRepository : GenericRepository<Actor>, IActorRepository
{
    public ActorRepository(IConfiguration config, PagilaDbContext context) : base(config, context)
    {
    }

    public IEnumerable<Actor> GetActiveActors()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Actor>> GetAll()
    {
        const string sql = @"SELECT actor_id AS ActorId, first_name AS FirstName, last_name AS LastName, age, is_active AS IsActive
                             FROM actor";

        using var conn = GetConnection();
        return await conn.QueryAsync<Actor>(sql);
    }

    public override async Task<Actor?> GetByIdAsync(int id)
    {
        const string sql = @"SELECT actor_id AS ActorId, first_name AS FirstName, last_name AS LastName, age, is_active AS IsActive
                             FROM actor
                             WHERE actor_id = @Id";

        using var conn = GetConnection();
        return await conn.QueryFirstOrDefaultAsync<Actor>(sql, new { Id = id });
    }

}
