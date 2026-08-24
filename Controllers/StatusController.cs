using MediatR;
using MercuriusReact.InventoryService.Features.Status;
using Microsoft.AspNetCore.Mvc;

namespace MercuriusReact.InventoryService.Controllers;

[ApiController]
[Route("api/[controller]")] // "[controller]" becomes "Status" (class name minus "Controller"), so this serves /api/status
public sealed class StatusController : ControllerBase
{
    private readonly IMediator _mediator;

    // Notice this controller has no business logic and no database access —
    // it only depends on IMediator. This is the "thin controller" pattern:
    // the controller's whole job is translating an HTTP request into a
    // query/command object and translating the result back into an HTTP
    // response. All real logic lives in the handler, which can be tested on
    // its own without spinning up a web server at all.
    public StatusController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<StatusDto>> Get(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetStatusQuery(), cancellationToken);
        return Ok(result);
    }
}
