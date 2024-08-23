using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories.DoctorRepository;
using eAppointmentServer.Infrastructure.Context;

namespace eAppointmentServer.Infrastructure.Repository.DoctorRepository;

public class DoctorWriteRepository : WriteRepository<Doctor>, IDoctorWriteRepository
{
    public DoctorWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}
