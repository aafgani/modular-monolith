using System;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Infrastructure.Persistence.Repository;

public class BaseRepository
{
    private readonly string _connectionString;
    public BaseRepository(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("DefaultConnection")!;
    }
    protected NpgsqlConnection GetConnection() => new(_connectionString);
}
