using EventManagement.API.Extensions.Handlers;
using EventManagement.API.Extensions.Registrations;
using EventManagement.Application.Extensions.Registrations;
using EventManagement.Infrastructure.Extensions.Registrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Extend services with application layer services
builder.Services.AddApplicationServices(builder.Configuration);

// Extend services with infrastructure layer services
builder.Services.AddInfrastructureServices(builder.Configuration);

// Extend services with api layer services
builder.Services.AddAPIServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Dictate to use custom exception handler
//app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
