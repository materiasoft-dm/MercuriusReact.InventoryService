namespace MercuriusReact.InventoryService.Features.Status;

// The shape of data sent back to the client. Keeping this separate from any
// future database entity means the API's public contract can stay stable
// even if the internal database model changes later — the DTO is what React
// sees; the entity (once we add one) is what the database sees.
public sealed record StatusDto(string Message, DateTime ServerTimeUtc);
