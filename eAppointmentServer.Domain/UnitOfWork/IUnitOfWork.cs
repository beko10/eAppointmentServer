using eAppointmentServer.Domain.Repositories.AppointmentRepository;
using eAppointmentServer.Domain.Repositories.DoctorRepository;
using eAppointmentServer.Domain.Repositories.PatientRepository;

namespace eAppointmentServer.Domain.UnitOfWork;

public interface IUnitOfWork:IDisposable
{
    public Task<int> CommitAsync();

}
