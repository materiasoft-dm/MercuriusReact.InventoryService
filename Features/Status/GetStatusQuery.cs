using MediatR;

namespace MercuriusReact.InventoryService.Features.Status;

// This is the "Q" in CQRS: a Query is a request object that describes a read
// — it never changes any data. Instead of one big "StatusService" class with
// a GetStatus() method, CQRS models each operation as its own small object.
// IRequest<StatusDto> tells MediatR "sending this will eventually produce a
// StatusDto". This query happens to need no input, so the record is empty.
public sealed record GetStatusQuery : IRequest<StatusDto>;
