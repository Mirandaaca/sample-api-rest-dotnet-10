using CIWithJenkins.Context;
using CIWithJenkins.Handlers;
using CIWithJenkins.Interfaces.Repository;
using CIWithJenkins.Interfaces.Services;
using CIWithJenkins.Repository;
using CIWithJenkins.Services;
using CIWithJenkins.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Generate error responses in ProblemDetails format (RFC 9457) and register
// the handler that translates domain exceptions to HTTP codes
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<DomainExceptionHandler>();

// Discover by reflection all AbstractValidator<T> in the assembly and registers them
// as IValidator<T>. The name of each class is irrelevant: what matters is the generic type parameter T, which is the type that the validator validates
builder.Services.AddValidatorsFromAssemblyContaining<ClientValidator>();

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

// Debe ir primero: envuelve al resto del pipeline para poder atrapar
// Must go first: it wraps the rest of the pipeline to be able to catch any exception that occurs within it
app.UseExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
