var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Scans this project's assembly for every class that implements
// IRequestHandler<,> (like GetStatusQueryHandler) and registers it with the
// DI container. That's how IMediator.Send(...) later knows which handler to
// call for a given query/command — it looks up the match by type.
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Deliberately no UseHttpsRedirection() here: the Gateway forwards to this
// service over plain HTTP (see the Gateway's appsettings.json cluster
// address), since it's internal, trusted traffic on localhost — not
// something a browser ever talks to directly. Forcing HTTPS here would just
// redirect the Gateway's proxied request straight back out to this
// service's own port, bypassing the Gateway entirely.

// This service is one microservice among several — it's never called
// directly by the browser. The Gateway (server/MercuriusReact.Gateway) is
// the only thing the browser talks to; it forwards requests here over the
// network. That's why there's no static-file serving or SPA fallback in
// this Program.cs anymore — only the Gateway hosts the React app.
app.UseAuthorization();

app.MapControllers();

app.Run();
