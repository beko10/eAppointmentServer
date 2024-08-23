using eAppointmentServer.Domain.UnitOfWork;
using eAppointmentServer.Infrastructure.Context;

namespace eAppointmentServer.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{

    private readonly ApplicationDbContext _contex;

    public UnitOfWork(ApplicationDbContext contex)
    {
        _contex = contex;
    }

    public async Task<int> CommitAsync()
    {
        return await _contex.SaveChangesAsync();
    }

    public void Dispose()
    {
        _contex.Dispose();  
    }
}
