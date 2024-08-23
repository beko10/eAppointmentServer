using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories.PatientRepository;
using eAppointmentServer.Infrastructure.Context;

namespace eAppointmentServer.Infrastructure.Repository.PatientRepository;

public class PatientReadRepository : ReadRepository<Patient>, IPatientReadRepository
{
    public PatientReadRepository(ApplicationDbContext contex) : base(contex)
    {
    }
}
