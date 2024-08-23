using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories.AppointmentRepository;
using eAppointmentServer.Infrastructure.Context;

namespace eAppointmentServer.Infrastructure.Repository.AppointmentRepository;

public class AppointmentReadRepository : ReadRepository<Appointment>, IAppointmentReadRepository
{
    public AppointmentReadRepository(ApplicationDbContext contex) : base(contex)
    {
    }
}
