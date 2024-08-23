using eAppointmentServer.Domain.Entities;
using System.Linq.Expressions;

namespace eAppointmentServer.Domain.Repositories;

public interface IReadRepository<T> where T : EntityBase
{
    IQueryable<T> GetAll(bool tracking = true);
    IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool tracking = true);
    Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool tracking = true);
    Task<T> GetByIdAsync(string id, bool tracking = true);
}
