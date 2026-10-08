using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrailHub.Infrastructure.Persistence;
using TrailHub.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddHealthChecks().AddNpgSql(builder.Configuration.GetConnectionString("DefaultConnection")!);

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITrailRepository, TrailRepository>();

builder.Services.AddScoped<CreateTrailUseCase>();

builder.Services.AddScoped<DeleteTrailUseCase>();

builder.Services.AddScoped<FindTrailUseCase>();

builder.Services.AddScoped<EditTrailUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapHealthChecks("/health");

app.MapPost("/trails", async (CreateTrailUseCase useCase, CreateTrailRequest request) =>
{
    await useCase.ExecuteAsync(request);
}).WithName("CreateTrail");

app.MapDelete("/trails", async (DeleteTrailUseCase useCase, string trailName) =>
{
    await useCase.ExecuteAsync(trailName);
}).WithName("DeleteTrail");

app.MapGet("/trails", async (FindTrailUseCase useCase, string trailName) =>
{
    await useCase.ExecuteAsync(trailName);
}).WithName("FindTrail");

app.MapPut("/trails", async (EditTrailUseCase useCase, EditTrailRequest request) =>
{
    await useCase.ExecuteAsync(request);
}).WithName("EditTrail");


app.Run();