using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace eAppointmentServer.WebAPI.Abstraction;

[Route("api/[controller]/[action]")]
[ApiController]
public abstract class BaseApiController: ControllerBase
{
    public readonly IMediator _mediator;

    protected BaseApiController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
