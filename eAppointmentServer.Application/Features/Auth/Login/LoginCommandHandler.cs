using eAppointmentServer.Application.Service;
using eAppointmentServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eAppointmentServer.Application.Features.Auth.Login;

internal sealed class LoginCommandHandler(UserManager<AppUser> userManager,IJwtProvider jwtProvider) : IRequestHandler<LoginCommandRequest, Result<LoginCommandResponse>>
{
    public async Task<Result<LoginCommandResponse>> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        AppUser? appUser = await userManager.Users.FirstOrDefaultAsync(u => u.UserName == request.UserNameOrEmail || u.Email == request.UserNameOrEmail,cancellationToken);

        if (appUser is null)
        {
            return Result<LoginCommandResponse>.Failure("User Not Found");
        }

        bool isPasswordCorrect = await userManager.CheckPasswordAsync(appUser,request.Password);

        if (!isPasswordCorrect)
        {
            return Result<LoginCommandResponse>.Failure("Password is wrong");
        }

        string token = jwtProvider.CreateToken(appUser);
        return Result<LoginCommandResponse>.Success(new LoginCommandResponse(token));

    }
    
}
