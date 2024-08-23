using eAppointmentServer.Application.Features.Auth.Login;
using eAppointmentServer.WebAPI.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eAppointmentServer.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthsController :BaseApiController
    {
        protected AuthsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest loginCommandRequest,CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(loginCommandRequest, cancellationToken);
           
            return StatusCode(response.StatusCode,response);
        }
    }
}
