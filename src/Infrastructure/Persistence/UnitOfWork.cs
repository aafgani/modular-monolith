using System;
using Application.Abstractions.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;

namespace Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private PagilaDbContext context;
    private IActorRepository Actors;

    public UnitOfWork(PagilaDbContext context,
    IActorRepository actorRepository)
    {
        this.context = context;
        this.Actors = actorRepository;
    }

    private bool disposed = false;

    IActorRepository IUnitOfWork.Actors => Actors;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    Task<int> IUnitOfWork.SaveAsync()
    {
        return context.SaveChangesAsync();
    }
}
