using Mediator.Abstractions;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Application;
using RepositoryPattern.Application.UseCases.Products.Create;
using RepositoryPattern.Application.UseCases.Products.GetById;
using RepositoryPattern.Domain.Configurations;
using RepositoryPattern.Infrastructure;
using RepositoryPattern.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

Configuration.ConnectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new Exception("ConnectionString not found!");

builder.Services.AddDbContext<AppDbContext>( x =>
{
    x.UseNpgsql(Configuration.ConnectionString, b
        => b.MigrationsAssembly("RepositoryPattern.Infrastructure"));
});

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("v1/products/{id}", async (
    IMediator mediator,
    Guid id,
    CancellationToken cancellationToken) =>
{
    var query = new Query(id);
    var result = await mediator.SendAsync(query, cancellationToken);

    return result.IsSuccess
        ? Results.Ok(result.Value)
        : Results.BadRequest(result.Error);
});

app.MapPost("v1/products", async (
    IMediator mediator,
    Command command,
    CancellationToken cancellationToken) =>
{
    var result = await mediator.SendAsync(command, cancellationToken);

    return result.IsSuccess
        ? Results.Ok(result.Value)
        : Results.BadRequest(result.Error);
});

app.Run();
