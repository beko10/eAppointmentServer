using MediatR;

namespace eAppointmentServer.Application.Features.Auth.Login;

public sealed record LoginCommandRequest(string UserNameOrEmail,string Password):IRequest<Result<LoginCommandResponse>>;
