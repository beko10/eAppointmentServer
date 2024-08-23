using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories.DoctorRepository;
using eAppointmentServer.Infrastructure.Context;
namespace eAppointmentServer.Infrastructure.Repository.DoctorRepository;

public sealed class DoctorReadRepository : ReadRepository<Doctor>,IDoctorReadRepository
{
    public DoctorReadRepository(ApplicationDbContext contex) : base(contex)
    {
    }
}
