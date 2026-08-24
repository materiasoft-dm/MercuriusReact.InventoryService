using MediatR;

namespace MercuriusReact.InventoryService.Features.Status;

// The handler is where the real work happens. MediatR discovers this class
// automatically at startup (via assembly scanning configured in Program.cs)
// because it implements IRequestHandler<GetStatusQuery, StatusDto> — it
// matches the query's input/output types, so MediatR knows to route
// GetStatusQuery requests here without either side referencing the other
// directly. That indirection is the main point of CQRS via a mediator:
// controllers depend only on IMediator, never on a specific handler class.
public sealed class GetStatusQueryHandler : IRequestHandler<GetStatusQuery, StatusDto>
{
    public Task<StatusDto> Handle(GetStatusQuery request, CancellationToken cancellationToken)
    {
        var dto = new StatusDto("MercuriusReact Inventory service is running.", DateTime.UtcNow);

        // No real async work happens here yet (no database call, no I/O), but
        // the handler still returns a Task because IRequestHandler requires
        // it — every handler must be awaitable, even a trivial one like this.
        return Task.FromResult(dto);
    }
}
