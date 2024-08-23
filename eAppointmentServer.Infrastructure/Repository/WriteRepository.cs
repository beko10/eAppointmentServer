using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using eAppointmentServer.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eAppointmentServer.Infrastructure.Repository;

public class WriteRepository<T> : IWriteRepsoitory<T> where T : EntityBase
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public WriteRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    public async Task<bool> AddAsync(T entity)
    {
        EntityEntry entityEntry = await _dbSet.AddAsync(entity);
        return entityEntry.State == EntityState.Added;
    }

    public async Task<bool> AddRangeAsync(List<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
        bool allAdded = entities.All(e => _context.Entry(e).State == EntityState.Added);
        return allAdded;
    }

    public bool Remove(T entity)
    {
        EntityEntry entityEntry = _dbSet.Remove(entity);
        return entityEntry.State == EntityState.Deleted;

    }

    public async Task<bool> RemoveAsync(string id)
    {
        T entity = (await _dbSet.FirstOrDefaultAsync(e => e.Equals(id)))!;
        return Remove(entity);
    }

    public bool Update(T entity)
    {
        EntityEntry entityEntry = _dbSet.Update(entity);
        return entityEntry.State == EntityState.Modified;
    }
}
