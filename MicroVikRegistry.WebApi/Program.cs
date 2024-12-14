using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MicroVikRegistry.WebApi.Database;
using MicroVikRegistry.WebApi.Endpoints;
using MicroVikRegistry.WebApi.Nodes.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.CustomSchemaIds(t => t.FullName?.Replace('+','.')));

builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseNpgsql(builder.Configuration["ConnectionString"]));

builder.Services.AddSingleton<INodeRepository, NodeRepository>();

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddHealthChecks();

builder.Services.AddEndpoints();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/health");

app.MapEndpoints();

app.Run();
