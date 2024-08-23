using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories.AppointmentRepository;
using eAppointmentServer.Infrastructure.Context;

namespace eAppointmentServer.Infrastructure.Repository.AppointmentRepository;

public class AppointmentWriteRepository : WriteRepository<Appointment>, IAppointmentWriteRepository
{
    public AppointmentWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}
