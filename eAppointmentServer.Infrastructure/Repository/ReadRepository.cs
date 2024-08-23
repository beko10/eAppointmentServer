using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using eAppointmentServer.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eAppointmentServer.Infrastructure.Repository;

public class ReadRepository<T> : IReadRepository<T> where T : EntityBase
{
    private readonly ApplicationDbContext _contex;
    private readonly DbSet<T> _dbSet;
    public ReadRepository(ApplicationDbContext contex)
    {
        _contex = contex;
        _dbSet = _contex.Set<T>();
    }

    public IQueryable<T> GetAll(bool tracking = true)
    {
        var query = _dbSet.AsQueryable();
        if(!tracking)
        {
            query = query.AsNoTracking();
        }
        return query;
    }

    public async Task<T> GetByIdAsync(string id, bool tracking = true)
    {
        var query = _dbSet.AsQueryable();
        if(!tracking)
        {
            query = query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync(e => e.Id== Guid.Parse(id));
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool tracking = true)
    {
        var query = _dbSet.AsQueryable();
        if(!tracking)
        {
            query = query.AsNoTracking();
        }
        return await query.FirstOrDefaultAsync(expression);
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool tracking = true)
    {
        var query = _dbSet.Where(expression);
        if (!tracking)
        {
            query = query.AsNoTracking();
        }
        return query;
    }
}
