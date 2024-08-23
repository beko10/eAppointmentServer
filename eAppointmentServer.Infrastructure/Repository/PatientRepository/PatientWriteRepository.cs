using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories.PatientRepository;
using eAppointmentServer.Infrastructure.Context;

namespace eAppointmentServer.Infrastructure.Repository.PatientRepository;

public class PatientWriteRepository : WriteRepository<Patient>, IPatientWriteRepository
{
    public PatientWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}
