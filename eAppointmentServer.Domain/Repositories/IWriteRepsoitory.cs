using eAppointmentServer.Domain.Entities;

namespace eAppointmentServer.Domain.Repositories;

public interface IWriteRepsoitory<T> where T : EntityBase
{
    Task<bool> AddAsync(T entity);
    Task<bool> AddRangeAsync(List<T> entities);
    bool Update(T entity);
    bool Remove(T entity);
    Task<bool> RemoveAsync(string id);
}
