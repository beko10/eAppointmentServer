using eAppointmentServer.Domain.Entities;

namespace eAppointmentServer.Application.Service;

public interface IJwtProvider
{
    string CreateToken(AppUser user);
}
